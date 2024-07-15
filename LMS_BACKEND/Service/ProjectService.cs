using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

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

        public async Task CreatNewProject(CreateProjectRequestModel model)
        {
            var hold = _mapper.Map<Project>(model);

            hold.Id = Guid.NewGuid();
            hold.CreatedDate = DateTime.Now;
            hold.ProjectStatusId = 1;
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
            _repository.member.Create(member);
            _repository.project.Create(hold);
            await _repository.folder.AddFolder(root);
            await _repository.Save();
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            var hold = await _repository.project.FindAllAsync(false);
            if (hold == null) throw new BadRequestException("Can not find any project");
            return hold;
        }

        public IEnumerable<ProjectResponseModel> GetOnGoingProjects(string userId)
        {
            var projectIds = _repository.member
                .GetByCondition(m => m.UserId != null && m.UserId.Equals(userId), false)
                .Select(m => m.ProjectId)
                .ToList();

            var projects = _repository.project
                .GetByCondition(p => projectIds.Contains(p.Id), false)
                .Where(p => p.ProjectStatusId == 2)
                .ToList();

            if (!projects.Any())
                throw new BadRequestException("No projects found for the specified user.");

            var result = _mapper.Map<IEnumerable<ProjectResponseModel>>(projects);

            return result;
        }

        public IEnumerable<ProjectResponseModel> GetProjects(string userId)
        {
            var projectIds = _repository.member
                .GetByCondition(m => m.UserId != null && m.UserId.Equals(userId), false)
                .Select(m => m.ProjectId)
                .ToList();

            var projects = _repository.project
                .GetByCondition(p => projectIds.Contains(p.Id), false)
                .ToList();

            if (!projects.Any())
                throw new BadRequestException("No projects found for the specified user.");

            var result = _mapper.Map<IEnumerable<ProjectResponseModel>>(projects);

            return result;
        }

        public async Task UpdateProject(Guid projectId, UpdateProjectRequestModel model)
        {
            model.Id = projectId;
            var hold = _mapper.Map<Project>(model);
            await _repository.Save();
        }

        public async Task<GetFolderContentResponseModel> GetProjectResources(Guid ProjectID)
        {

            var root = await _repository.folder.GetRootByProjectId(ProjectID).FirstOrDefaultAsync() ?? throw new Exception("Project associated with that ID currently doesn't have a root");

            var end = await _repository.file.GetFiles(false, root.Id);

            var folders = new List<Folder>();

            return new GetFolderContentResponseModel { Files = end.ToList(), Folders = folders };
        }
        public async Task<IEnumerable<AccountRequestJoinResponseModel>> GetJoinRequest(Guid projectId)
        {
            var hold = await _repository.member.GetByCondition(x => x.ProjectId.Equals(projectId) && !x.IsValidTeamMember, false).Include(y => y.User).ToListAsync();
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
                    .member
                    .GetByCondition(x => x.UserId.Equals(item.Id) && x.ProjectId.Equals(id) && x.ProjectId.Equals(item.ProjectID), false)
                    .FirstOrDefaultAsync() ?? throw new Exception("Error due to database logic");

                if (item.Accepted) _repository.member.Delete(hold);

                else hold.IsValidTeamMember = true;
            }
            await _repository.Save();
        }
    }
}
