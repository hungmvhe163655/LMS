using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
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

        public ProjectService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProjectResponseModel> CreatNewProject(CreateProjectRequestModel model)
        {
            var hold = _mapper.Map<Project>(model);

            hold.Id = Guid.NewGuid();
            hold.CreatedDate = DateTime.Now;
            hold.ProjectStatus = PROJECT_STATUS.INITIALIZING;
            var rootid = Guid.NewGuid();
            var root = new Folder
            {
                Id = rootid,
                CreatedBy = model.CreatedBy,
                CreatedDate = DateTime.Now,
                IsRoot = true,
                LastModifiedDate = DateTime.Now,
                ProjectId = hold.Id,
                Name = hold.Id + "Root",
                FolderClosureAncestor = new List<FolderClosure> { new FolderClosure { AncestorID = rootid, DescendantID = rootid, Depth = 0 } }
            };
            var member = new Member
            {
                UserId = model.CreatedBy,
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

            foreach (var project in projectsDto)
            {
                project.TaskUndone = _repository.Task.CountAllTaskUndone(project.Id).Result;
            }

            return (projects: projectsDto, metaData: projectFromDb.MetaData);
        }

        public async Task<(IEnumerable<ProjectResponseModel> projects, MetaData metaData)> GetOnGoingProjects(string userId, ProjectRequestParameters projetParameter, bool trackChange)
        {
            var projectFromDb = await _repository.Project.GetOngoingProjectAsync(userId, projetParameter, trackChange) ?? throw new BadRequestException("No projects found for the specified user.");

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseModel>>(projectFromDb);

            foreach (var project in projectsDto) 
            {
                project.TaskUndone = _repository.Task.CountTaskUndone(userId, project.Id).Result;
            }

            return (projects: projectsDto, metaData: projectFromDb.MetaData);
        }

        public async Task<(IEnumerable<ProjectResponseModel> projects, MetaData metaData)> GetProjects(string userId, ProjectRequestParameters projetParameter, bool trackChange)
        {
            var projectFromDb = await _repository.Project.GetProjectAsync(userId, projetParameter, trackChange) ?? throw new BadRequestException("No projects found for the specified user.");

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseModel>>(projectFromDb);

            foreach (var project in projectsDto)
            {
                project.TaskUndone = _repository.Task.CountTaskUndone(userId, project.Id).Result;
            }

            return (projects: projectsDto, metaData: projectFromDb.MetaData);
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

            return new GetFolderContentResponseModel { Files = end.ToList(), Folders = folders };
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
