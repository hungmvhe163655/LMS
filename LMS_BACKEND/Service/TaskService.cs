using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
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
            return _mapper.Map<IEnumerable<TaskResponseModel>>(await _repository.Task.GetTasksWithProjectId(projectId, false).ToListAsync());
        }

        public async Task<IEnumerable<TaskResponseModel>> GetTasksWithTaskListId(Guid taskListId)
        {
            return _mapper.Map<IEnumerable<TaskResponseModel>>(await _repository.Task.GetTasksWithTaskListId(taskListId, false).ToListAsync());
        }

        public async Task CreateTask(TaskCreateRequestModel model)
        {
            var hold = _mapper.Map<Tasks>(model);

            var hold_creator = await
                _repository
                .Account
                .GetByCondition(x => x.Id.Equals(model.CreatedBy), true)
                .Include(y => y.Members
                .Where(z => z.IsLeader && z.ProjectId
                .Equals(model.ProjectId) && z.UserId
                .Equals(model.CreatedBy)))
                .FirstOrDefaultAsync();
            var hold_worker = await
                _repository
                .Account
                .GetByCondition(x => x.Id
                .Equals(model.AssignedTo), true)
                .Include(y => y.Members
                .Where(z => z.ProjectId
                .Equals(model.ProjectId) && z.UserId
                .Equals(model.AssignedTo)))
                .FirstOrDefaultAsync();

            if (hold_creator == null) throw new BadRequestException("User Id does not existed or not in this project");

            if (hold_worker == null) throw new BadRequestException("Assigned user id does not existed or not in this project");

            hold.Id = Guid.NewGuid();

            hold.CreatedDate = DateTime.Now;

            var hold_version = _mapper.Map<TaskHistory>(hold);

            hold_version.Id = Guid.NewGuid();

            hold_version.EditDate = DateTime.Now;

            hold_worker.TaskHistories.Add(hold_version);

            await _repository.Task.AddNewTask(hold);

            await _repository.Save();
        }

        public async Task EditTask(TaskUpdateRequestModel model)
        {
            var hold = _mapper.Map<Tasks>(model);

            var hold_worker = await
               _repository
               .Account
               .GetByCondition(x => x.Id
               .Equals(model.AssignedTo), true)
               .Include(y => y.Members
               .Where(z => z.ProjectId
               .Equals(model.ProjectId) && z.UserId
               .Equals(model.AssignedTo)))
               .FirstOrDefaultAsync();

            if (hold_worker == null) throw new BadRequestException("Assigned user id does not existed or not in this project");

            var hold_version = _mapper.Map<TaskHistory>(hold);

            hold_version.Id = Guid.NewGuid();

            hold_version.EditDate = DateTime.Now;

            hold_worker.TaskHistories.Add(hold_version);

            await _repository.Task.UpdateTask(hold);

            await _repository.Save();
        }
        public async Task DeleteTask(Guid id, string userId)
        {
            var hold = _repository.Task.GetTaskWithId(id, false).First();

            var hold_creator = await
                _repository
                .Account
                .GetByCondition(x => x.Id
                .Equals(userId), true)
                .Include(y => y.Members
                .Where(z => z.IsLeader && z.IsLeader && z.ProjectId
                .Equals(hold.ProjectId) && z.UserId
                .Equals(userId)))
                .FirstOrDefaultAsync();

            if (hold_creator == null) throw new BadRequestException("User is not allow to interract with this project");

            _repository.TaskHistory.DeleteTaskHistory(id);

            await _repository.Task.DeleteTask(hold);

            await _repository.Save();
        }

        public async Task<(IEnumerable<TaskResponseModel> tasks, MetaData metaData)> GetTasksByUser(string userId, TaskRequestParameters parameters)
        {
            var taskFromDb = await _repository.task.GetAllTaskByUser(userId, parameters, false);

            if (!taskFromDb.Any()) throw new BadRequestException("No task found for specified user.");

            var tasksDto= _mapper.Map<IEnumerable<TaskResponseModel>>(taskFromDb);

            return (tasks: tasksDto, metaData: taskFromDb.MetaData);

        }
        
        public async Task<TaskResponseModel> GetTaskByID(Guid id)
        {
            return _mapper.Map<TaskResponseModel>(await _repository.Task.GetTaskWithId(id, false).FirstAsync());
        }

        public async Task<(TaskUpdateRequestModel taskToPatch, Tasks taskEntity, Guid oldLitId)> MoveTaskForPatch(Guid taskListId, Guid taskId)
        {
            var taskList = await _repository.TaskList.GetByCondition(x => x.Id.Equals(taskListId), false).Include(x =>x.Tasks).FirstOrDefaultAsync() ?? throw new BadRequestException($"Can not find task list with id {taskListId}");

            _ = taskList.Tasks.Where(x => x.Id.Equals(taskId)).FirstOrDefault() ?? throw new BadRequestException("no such task exist in inputed list");

            var hold = await _repository.Task.GetTaskWithId(taskId, true).FirstOrDefaultAsync() ?? throw new BadRequestException($"Can not find task with id {taskId}");

            var taskToPatch = _mapper.Map<TaskUpdateRequestModel>(hold);

            return (taskToPatch, hold, hold.TaskListId);
        }

        public async Task<Guid> SaveChangesForPatch(TaskUpdateRequestModel taskToPatch, Tasks taskEntity, string userId)
        {
            if (!IsTaskListAvailable(taskEntity.TaskListId).Result) throw new BadRequestException("Task lists already have maximum tasks");

            if (!IsMemberInProject(taskEntity.TaskListId, userId).Result) throw new BadRequestException("Member is not in project");

            _mapper.Map(taskToPatch, taskEntity);

             await _repository.Save();

            return taskEntity.TaskListId;
        }

        public async Task<bool> IsTaskListAvailable(Guid taskListId)
        {
            var taskList = await _repository.TaskList.GetByCondition(x => x.Id.Equals(taskListId), false).FirstOrDefaultAsync() ?? throw new BadRequestException($"Can not find task list with id {taskListId}");

            var count = await _repository.Task.GetTasksWithTaskListId(taskListId, false).CountAsync();

            if (count < taskList.MaxTasks)
            {
                return true;
            }
            else return false;
        }

        public async Task<bool> IsMemberInProject(Guid taskListId, string userId)
        {
            var taskList = await _repository.TaskList.GetByCondition(x => x.Id.Equals(taskListId), false).FirstOrDefaultAsync() ?? throw new BadRequestException($"Can not find task list with id {taskListId}");

            var user = await _repository.Member.GetByCondition(x => x.UserId.Equals(userId) && x.ProjectId.Equals(taskList.ProjectId), false).FirstOrDefaultAsync() ?? throw new BadRequestException($"Can not find member with userid {userId}");

            if (user == null)
            {
                return false;
            }
            else return true;
        }
        public async Task<(IEnumerable<TaskResponseModel> tasks, MetaData metaData)> GetTasksByUser(string userId, TaskRequestParameters parameters)
        {
            var taskFromDb = await _repository.Task.GetAllTaskByUser(userId, parameters, false);

            if (!taskFromDb.Any()) throw new BadRequestException("No task found for specified user.");

            var tasksDto= _mapper.Map<IEnumerable<TaskResponseModel>>(taskFromDb);

            return (tasks: tasksDto, metaData: taskFromDb.MetaData);

        }
    }
}
