using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
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
            var member = new Member
            {
                UserId = model.CreatedBy,
                ProjectId = hold.Id,
                IsLeader = true,
                JoinDate = DateTime.Now,
            };
            _repository.member.Create(member);
            _repository.project.Create(hold);
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
    }
}
