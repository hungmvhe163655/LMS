using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using Servive.Hubs;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using Shared.GlobalVariables;

namespace Service
{
    public class ProjectService : IProjectService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IHubContext<NotificationHub> _hubContext;

        public ProjectService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProjectResponseModel> CreatNewProject(string userId, CreateProjectRequestModel model)
        {
            var hold = _mapper.Map<Project>(model);

            hold.Id = Guid.NewGuid();
            hold.CreatedDate = DateTime.Now;
            hold.ProjectStatus = PROJECT_STATUS.INITIALIZING;
            var rootid = Guid.NewGuid();
            var root = new Folder
            {
                Id = rootid,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                IsRoot = true,
                LastModifiedDate = DateTime.Now,
                ProjectId = hold.Id,
                Name = hold.Id + "Root",
                FolderClosureAncestor = new List<FolderClosure> { new FolderClosure { AncestorID = rootid, DescendantID = rootid, Depth = 0 } }
            };
            var member = new Member
            {
                UserId = userId,
                ProjectId = hold.Id,
                IsLeader = true,
                JoinDate = DateTime.Now,
            };
            _repository.Member.Create(member);
            _repository.Project.Create(hold);
            await _repository.Folder.AddFolder(root);
            await _repository.Save();

            return _mapper.Map<ProjectResponseModel>(hold);
        }

        public async Task<(IEnumerable<ProjectResponseModel> projects, MetaData metaData)> GetAllProjects(ProjectRequestParameters projetParameter, bool trackChange)
        {
            var projectFromDb = await _repository.Project.GetAllProjectsAsync(projetParameter, trackChange) ?? throw new BadRequestException("No projects found for the specified user.");

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseModel>>(projectFromDb);

            return (projects: projectsDto, metaData: projectFromDb.MetaData);
        }

        public async Task UpdateProject(ProjectUpdateRequestModel model, Guid id, string userID)
        {
            if (model.LeaderId != null && model.LeaderId.Equals(userID)) throw new BadRequestException("Bad request");

            var newLeaderID = model.LeaderId;

            var hold = await _repository.Project.GetByCondition(x => x.Id.Equals(id), true).FirstOrDefaultAsync() ?? throw new BadRequestException("Invalid project");

            var members = await _repository.Member.GetByCondition(x => x.ProjectId.Equals(id) && x.IsValidTeamMember, true).ToListAsync() ?? throw new BadRequestException("Project doesn't have any member");

            if (!members.Where(x => x.IsLeader).Select(y => y.UserId).Contains(userID)) throw new BadRequestException("user don't have permission to work in this project");

            var hold_new_leader = members.Where(x => !x.IsLeader && x.UserId.Equals(newLeaderID)).FirstOrDefault();

            if (hold_new_leader != null)
            {
                var hold_old_leader = members.Where(x => x.IsLeader && !x.UserId.Equals(userID)).FirstOrDefault();

                if (hold_old_leader != null) hold_old_leader.IsLeader = false;

                hold_new_leader.IsLeader = true;
            }
            _mapper.Map(model, hold);    

            await _repository.Save();
        }

        public async Task<(IEnumerable<ProjectResponseModel> projects, MetaData metaData)> GetProjects(string userId, ProjectRequestParameters projetParameter, bool trackChange)
        {
            var projectFromDb = await _repository.Project.GetProjectAsync(userId, projetParameter, trackChange) ?? throw new BadRequestException("No projects found for the specified user.");

            var totalTaskUndone = 0;

            var projectsDto = projectFromDb.Select(p =>
            {
                var undoneTasks = p.TaskLists
                    .SelectMany(tl => tl.Tasks)
                    .Where(t => t.TaskStatus != TASK_STATUS.CLOSE)
                    .ToList();

                var taskUndoneCount = p.TaskLists.Sum(tl => tl.Tasks.Count(t => t.TaskStatus != TASK_STATUS.CLOSE));
                totalTaskUndone += taskUndoneCount;

                var taskUndoneListDto = _mapper.Map<IEnumerable<TasksViewResponseModel>>(undoneTasks);

                var projectDto = _mapper.Map<ProjectResponseModel>(p);
                projectDto.TaskUndone = taskUndoneCount;
                projectDto.ListTaskUndone = taskUndoneListDto;

                return projectDto;
            }).ToList();

            return (projects: projectsDto, metaData: projectFromDb.MetaData);
        }

        public async Task<ProjectResponseModel> GetProjectById(Guid id)
        {
            var hold = await _repository.Project.GetByCondition(p => p.Id.Equals(id), false).FirstOrDefaultAsync() ?? throw new BadRequestException($"Can't find project with id {id}");
            return (_mapper.Map<ProjectResponseModel>(hold));
        }

        public async Task UpdateProject(Guid projectId, UpdateProjectRequestModel model)
        {
            model.Id = projectId;
            var hold = _mapper.Map<Project>(model);
            await _repository.Save();
        }

        public async Task<GetFolderContentResponseModel> GetProjectResources(Guid ProjectID)
        {

            var root = await _repository.Folder.GetRootByProjectId(ProjectID).FirstOrDefaultAsync() ?? throw new Exception("Project associated with that ID currently doesn't have a root");

            var end = await _repository.File.GetFiles(false, root.Id);

            var folders = new List<Folder>();

            return new GetFolderContentResponseModel { Files = _mapper.Map<List<FileResponseModel>>(end.ToList()), Folders = _mapper.Map<List<FolderResponseModel>>(folders) };
        }
        public async Task<IEnumerable<AccountRequestJoinResponseModel>> GetJoinRequest(Guid projectId)
        {
            var hold = await _repository.Member.GetByCondition(x => x.ProjectId.Equals(projectId) && !x.IsValidTeamMember, false).Include(y => y.User).ToListAsync();
            List<Account> end = new List<Account>();
            foreach (var item in hold)
            {
                if (item.User != null) end.Add(item.User);
            }
            return _mapper.Map<List<AccountRequestJoinResponseModel>>(end);
        }
        public async Task ValidateJoinRequest(IEnumerable<UpdateStudentJoinRequestModel> Listmodel, Guid id)
        {
            foreach (var item in Listmodel)
            {
                var hold = await
                    _repository
                    .Member
                    .GetByCondition(x => x.UserId.Equals(item.Id) && x.ProjectId.Equals(id) && x.ProjectId.Equals(item.ProjectID), false)
                    .FirstOrDefaultAsync() ?? throw new Exception("Error due to database logic");

                if (!item.Accepted) _repository.Member.Delete(hold);

                else hold.IsValidTeamMember = true;
            }
            await _repository.Save();
        }
    }
}
