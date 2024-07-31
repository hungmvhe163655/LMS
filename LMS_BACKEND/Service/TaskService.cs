using AutoMapper;
using Contracts;
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
    public class TaskService : ITaskService
    {
        private readonly IRepositoryManager _repository;

        private readonly IMapper _mapper;

        // private readonly IRedisCacheHelper _cache;

        //public TaskService(IRepositoryManager repositoryManager, IMapper mapper, IRedisCacheHelper cache)
        public TaskService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repository = repositoryManager;

            _mapper = mapper;

            //  _cache = cache;
        }

        public async Task<IEnumerable<TaskResponseModel>> GetTasksWithProjectId(Guid projectId)
        {

            var hold = _mapper.Map<IEnumerable<TaskResponseModel>>(await _repository.Task.GetTasksWithProjectId(projectId, false).ToListAsync());

            return hold;
        }

        /*
        public async Task<IEnumerable<TaskResponseModel>> GetTasksWithProjectId(Guid projectId)
        {
            var data_cached = await _cache.GetCacheAsync<IEnumerable<TaskResponseModel>>(projectId.ToString() + nameof(GetTasksWithProjectId));

            if (data_cached == null)
            {
                var hold = _mapper.Map<IEnumerable<TaskResponseModel>>(await _repository.Task.GetTasksWithProjectId(projectId, false).ToListAsync());

                await _cache.SetCacheAsync<IEnumerable<TaskResponseModel>>(projectId.ToString() + nameof(GetTasksWithProjectId), hold, TimeSpan.FromHours(1));

                return hold;
            }
            else return data_cached;
        }
        */
        public async Task<IEnumerable<TaskResponseModel>> GetTasksWithTaskListId(Guid taskListId)
        {
            return _mapper.Map<IEnumerable<TaskResponseModel>>(await _repository.Task.GetTasksWithTaskListId(taskListId, false).ToListAsync());
        }

        public async Task<TaskResponseModel> CreateTask(TaskCreateRequestModel model, string hold_user)
        {
            var hold = _mapper.Map<Tasks>(model);

            hold.CreatedBy = hold_user;

            var hold_creator = await
                _repository
                .Member
                .GetByCondition(x => x.IsLeader && x.ProjectId
                .Equals(model.ProjectId) && x.UserId
                .Equals(hold_user), false)
                .FirstOrDefaultAsync();

            var hold_worker = await
                _repository
                .Member
                .GetByCondition(x => x.UserId
                .Equals(model.AssignedTo) && x.ProjectId
                .Equals(model.ProjectId), false)
                .Select(z => z.User)
                .FirstOrDefaultAsync();

            if (hold_creator == null) throw new BadRequestException("User Id does not existed or not in this project");

            if (hold_worker == null) hold.AssignedTo = null;

            hold.Id = Guid.NewGuid();

            hold.CreatedDate = DateTime.Now;

            var hold_version = _mapper.Map<TaskHistory>(hold);

            hold_version.Id = Guid.NewGuid();

            hold_version.EditDate = DateTime.Now;

            hold.TaskHistories.Add(hold_version);

            //hold_worker.TaskHistories.Add(hold_version);

            //_repository.Account.Update(hold_worker);

            await _repository.Task.AddNewTask(hold);

            await _repository.Save();

            return _mapper.Map<TaskResponseModel>(hold);
        }

        public async Task EditTask(TaskUpdateRequestModel model, Guid id, string editorId)
        {
            var hold = await _repository.Task.GetTaskWithId(id, false).Include(t => t.TaskHistories).FirstOrDefaultAsync() ?? throw new BadRequestException("Invalid task id");

            var hold_editor = await
              _repository
              .Member
              .GetByCondition(x => x.UserId.Equals(editorId) && x.ProjectId.Equals(hold.ProjectId) && x.IsLeader, false).FirstOrDefaultAsync() ?? throw new BadRequestException($"User does not have permission to managing tasks from this project");

            var hold_validmember = await _repository.Member.GetByCondition(x => x.UserId.Equals(model.AssignedTo), false).FirstOrDefaultAsync();

            _mapper.Map(model, hold);

            if (hold_validmember == null) hold.AssignedTo = null;

            var hold_version = _mapper.Map<TaskHistory>(hold);

            hold_version.Id = Guid.NewGuid();

            hold_version.EditDate = DateTime.Now;

            await _repository.TaskHistory.AddTaskHistory(hold_version);

            await _repository.Task.UpdateTask(hold);

            await _repository.Save();
        }

        public async Task AssignUserToTask(Guid taskId, string userId, string editorId)
        {
            var hold = await _repository.Task.GetTaskWithId(taskId, false).FirstOrDefaultAsync() ?? throw new BadRequestException("Invalid task id");

            var hold_editor = await
              _repository
              .Member
              .GetByCondition(x => x.UserId.Equals(editorId) && x.ProjectId.Equals(hold.ProjectId) && x.IsLeader, false).FirstOrDefaultAsync() ?? throw new BadRequestException($"User does not have permission to managing tasks from this project");

            var hold_worker = await
                _repository
                .Member
                .GetByCondition(x => x.UserId
                .Equals(userId) && x.ProjectId
                .Equals(hold.ProjectId), false)
                .Select(z => z.User)
                .FirstOrDefaultAsync() ?? throw new BadRequestException("User not exist or not in this project");

            hold.AssignedTo = hold_worker.Id;

            await _repository.Task.UpdateTask(hold);

            await _repository.Save();

        }

        public async Task DeleteTask(Guid id, string userId)
        {
            var hold = await _repository.Task.GetTaskWithId(id, false).FirstOrDefaultAsync() ?? throw new BadRequestException("Invalid Task id");

            var hold_creator = await
                _repository
                .Member
                .GetByCondition(x => x.UserId
                .Equals(userId) && x.ProjectId
                .Equals(hold.ProjectId) && x.IsLeader, false)
                .FirstOrDefaultAsync()
                ?? throw new BadRequestException("User is not allow to interract with this project");

            _repository.TaskHistory.DeleteTaskHistory(id);

            await _repository.Task.DeleteTask(hold);

            await _repository.Save();
        }

        public async Task<(IEnumerable<TaskResponseModel> tasks, MetaData metaData)> GetTasksByUser(string userId, TaskRequestParameters parameters)
        {
            var taskFromDb = await _repository.Task.GetAllTaskByUser(userId, parameters, false);

            if (!taskFromDb.Any()) throw new BadRequestException("No task found for specified user.");

            var tasksDto = _mapper.Map<IEnumerable<TaskResponseModel>>(taskFromDb);

            return (tasks: tasksDto, metaData: taskFromDb.MetaData);

        }

        public async Task<TaskResponseModel> GetTaskByID(Guid id)
        {
            return _mapper.Map<TaskResponseModel>(await _repository.Task.GetTaskWithId(id, false).FirstAsync());
        }

        public async Task<(TaskResponseModel taskToPatch, Tasks taskEntity)> GetTaskForPatch(Guid taskListId, Guid taskId)
        {
            var taskList = await _repository.TaskList.GetByCondition(x => x.Id.Equals(taskListId), false).Include(x => x.Tasks).FirstOrDefaultAsync() ?? throw new BadRequestException($"Can not find task list with id {taskListId}");

            _ = taskList.Tasks.Where(x => x.Id.Equals(taskId)).FirstOrDefault() ?? throw new BadRequestException("No such task exist in inputed list");

            var hold = await _repository.Task.GetTaskWithId(taskId, true).FirstOrDefaultAsync() ?? throw new BadRequestException($"Can not find task with id {taskId}");

            var taskToPatch = _mapper.Map<TaskResponseModel>(hold);

            return (taskToPatch, hold);
        }

        public async Task SaveChangesForPatch(TaskResponseModel taskToPatch, Tasks taskEntity, string userId)
        {
            if (!IsTaskListAvailable(taskEntity.TaskListId).Result) throw new BadRequestException("Task lists already have maximum tasks");

            if (!IsMemberInProject(taskEntity.TaskListId, userId).Result) throw new BadRequestException("Member is not in project");

            var task = _mapper.Map(taskToPatch, taskEntity);

            var taskListId = task.TaskListId;
            var tasks = await _repository.Task.GetTasksWithTaskListId(taskListId, true).OrderBy(t => t.Order).ToListAsync();

            task.Order = tasks.Count + 1;

            for (var i = 0; i < tasks.Count; i++)
            {
                tasks[i].Order = i + 1;
            }

            await _repository.Save();

        }

        public async Task SaveChangesInTaskListForPatch(TaskResponseModel taskToPatch, Tasks taskEntity, string userId)
        {
            if (!IsMemberInProject(taskEntity.TaskListId, userId).Result) throw new BadRequestException("Member is not in project");

            var task = _mapper.Map(taskToPatch, taskEntity);

            var taskListId = taskEntity.TaskListId;
            var tasks= await _repository.Task.GetTasksWithTaskListId(taskListId, true).OrderBy(t => t.Order).ToListAsync();

            if (taskToPatch.Order < 1 || taskToPatch.Order > tasks.Count) throw new BadRequestException("Invalid Order value");

            tasks.Remove(taskEntity);
            tasks.Insert(taskToPatch.Order - 1, task);

            for (var i = 0; i < tasks.Count; i++)
            {
                tasks[i].Order = i + 1;
            }

            await _repository.Save();
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
    }
}
