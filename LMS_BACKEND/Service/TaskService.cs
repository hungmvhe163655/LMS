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
    public class TaskService : ITaskService
    {
        private readonly IRepositoryManager _repository;

        private readonly IMapper _mapper;

        public TaskService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repository = repositoryManager;

            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskResponseModel>> GetTasksWithProjectId(Guid projectId)
        {
            return _mapper.Map<IEnumerable<TaskResponseModel>>(await _repository.task.GetTasksWithProjectId(projectId, false).ToListAsync());
        }

        public async Task<IEnumerable<TaskResponseModel>> GetTasksWithTaskListId(Guid taskListId)
        {
            return _mapper.Map<IEnumerable<TaskResponseModel>>(await _repository.task.GetTasksWithTaskListId(taskListId, false).ToListAsync());
        }

        public async Task CreateTask(TaskCreateRequestModel model)
        {
            var hold = _mapper.Map<Tasks>(model);

            var hold_creator = await
                _repository
                .account
                .GetByCondition(x => x.Id.Equals(model.CreatedBy), true)
                .Include(y => y.Members.Where(z => z.IsLeader && z.ProjectId.Equals(model.ProjectId) && z.UserId.Equals(model.CreatedBy)))
                .FirstOrDefaultAsync();
            var hold_worker = await
                _repository
                .account
                .GetByCondition(x => x.Id.Equals(model.AssignedTo), true)
                .Include(y => y.Members.Where(z => z.ProjectId.Equals(model.ProjectId) && z.UserId.Equals(model.AssignedTo)))
                .FirstOrDefaultAsync();

            if (hold_creator == null) throw new BadRequestException("User Id does not existed or not in this project");

            if (hold_worker == null) throw new BadRequestException("Assigned user id does not existed or not in this project");

            hold.Id = Guid.NewGuid();

            hold.CreatedDate = DateTime.Now;

            var hold_version = _mapper.Map<TaskHistory>(hold);

            hold_version.Id = Guid.NewGuid();

            hold_version.EditDate = DateTime.Now;

            hold_worker.TaskHistories.Add(hold_version);

            await _repository.task.AddNewTask(hold);

            await _repository.Save();
        }

        public async Task EditTask(TaskUpdateRequestModel model)
        {
            var hold = _mapper.Map<Tasks>(model);

            var hold_worker = await
               _repository
               .account
               .GetByCondition(x => x.Id.Equals(model.AssignedTo), true)
               .Include(y => y.Members.Where(z => z.ProjectId.Equals(model.ProjectId) && z.UserId.Equals(model.AssignedTo)))
               .FirstOrDefaultAsync();

            if (hold_worker == null) throw new BadRequestException("Assigned user id does not existed or not in this project");

            var hold_version = _mapper.Map<TaskHistory>(hold);

            hold_version.Id = Guid.NewGuid();

            hold_version.EditDate = DateTime.Now;

            hold_worker.TaskHistories.Add(hold_version);

            await _repository.task.UpdateTask(hold);

            await _repository.Save();
        }
        public async Task DeleteTask(Guid id, string userId)
        {
            var hold = _repository.task.GetTaskWithId(id, false).First();

            var hold_creator = await
                _repository
                .account
                .GetByCondition(x => x.Id.Equals(userId), true)
                .Include(y => y.Members.Where(z => z.IsLeader && z.IsLeader && z.ProjectId.Equals(hold.ProjectId) && z.UserId.Equals(userId)))
                .FirstOrDefaultAsync();

            if (hold_creator == null) throw new BadRequestException("User is not allow to interract with this project");

            _repository.taskHistory.DeleteTaskHistory(id);

            await _repository.task.DeleteTask(hold);

            await _repository.Save();
        }

        public async Task<TaskResponseModel> GetTaskByID(Guid id)
        {
            return _mapper.Map<TaskResponseModel>(await _repository.task.GetTaskWithId(id, false).FirstAsync());
        }
    }
}
