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
    public class TaskListService : ITaskListService
    {
        private readonly IRepositoryManager _repository;

        private readonly IMapper _mapper;

        public TaskListService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repository = repositoryManager;

            _mapper = mapper;
        }

        public async Task<TaskListResponseModel> GetTaskListById(Guid taskListId)
        {
            var hold = await
                _repository
                .TaskList
                .GetByCondition(x => x.Id.Equals(taskListId), false)
                .Include(y => y.Tasks)
                .ThenInclude(z => z.AssignedToUser)
                .ToListAsync();

            if (hold == null) throw new BadRequestException($"Can not found task list with id {taskListId}");
            var result = _mapper.Map<TaskListResponseModel>(hold.FirstOrDefault());
            return result;
        }

        public async Task<TaskListResponseModel> CreateTaskList(CreateTaskListRequestModel model)
        {
            var hold = _mapper.Map<TaskList>(model);

            hold.Id = Guid.NewGuid();

            hold.Order = 0;

            await _repository.TaskList.AddNewTaskList(hold);

            await _repository.Save();

            return _mapper.Map<TaskListResponseModel>(hold);
        }


        public async Task UpdateTaskList(UpdateTaskListRequestModel model)
        {
            var hold = _repository.TaskList.GetByCondition(x => x.Id.Equals(model.Id), true).FirstOrDefault();
            if (hold == null) throw new BadRequestException($"Can not find task list with id {model.Id}");
            var count = _repository.Task.GetTasksWithTaskListId(hold.Id, false).Count();
            if (count > model.MaxTasks) throw new BadRequestException($"Max task must greater than number current task on list");

            _mapper.Map(model, hold);
            await _repository.Save();
        }
        public async Task<IEnumerable<TaskListResponseModel>> GetTaskListByProject(Guid projectId)
        {
            var hold = await
                _repository
                .TaskList
                .GetByCondition(x => x.ProjectId.Equals(projectId), false).OrderBy(a => a.Order)
                .Include(y => y.Tasks.OrderBy(t => t.Order))
                .ThenInclude(z => z.AssignedToUser)
                .ToListAsync();

            if (hold == null) throw new BadRequestException($"Project {projectId} have no task list");
            var result = _mapper.Map<IEnumerable<TaskListResponseModel>>(hold);
            return result;
        }

        public async Task DeleteTaskList(Guid taskListId)
        {
            var count = _repository.Task.GetTasksWithTaskListId(taskListId, false).Count();
            if (count > 0) throw new BadRequestException("Can not delete task list have tasks inside");
            var hold = _repository.TaskList.GetByCondition(x => x.Id.Equals(taskListId), false).FirstOrDefault();
            if (hold == null) throw new BadRequestException($"Can not find task list with id {taskListId}");
            _repository.TaskList.Delete(hold);
            await _repository.Save();
        }

        public async Task<(TaskListUpdateRequestModel taskListToPatch, TaskList taskListEntity)> GetTaskListForPatch(Guid projectId, Guid taskListId)
        {
            var project = await _repository.Project.GetByCondition(x => x.Id.Equals(projectId), false).Include(x => x.TaskLists).FirstOrDefaultAsync() ?? throw new BadRequestException($"Can not find project with id {projectId}");

            _ = project.TaskLists.Where(x => x.Id.Equals(taskListId)).FirstOrDefault() ?? throw new BadRequestException("No such task exist in inputed list");

            var hold = await _repository.TaskList.GetByCondition(x => x.Id.Equals(taskListId), true).FirstOrDefaultAsync() ?? throw new BadRequestException($"Can not find task list with id {taskListId}");

            var taskListToPatch = _mapper.Map<TaskListUpdateRequestModel>(hold);

            return (taskListToPatch, hold);
        }

        public async Task SaveChangesForPatch(TaskListUpdateRequestModel taskListToPatch, TaskList taskListEntity, string userId)
        {
            if (!IsMemberInProject(taskListEntity.ProjectId, userId).Result) throw new BadRequestException("Member is not in project");

            var taskList = _mapper.Map(taskListToPatch, taskListEntity);

            var projectId = taskListEntity.ProjectId;
            var tasklists = await _repository.TaskList
                .GetByCondition(t => t.ProjectId.Equals(projectId), true)
                .OrderBy(t => t.Order)
                .ToListAsync();

            if (taskListToPatch.Order < 1 || taskListToPatch.Order > tasklists.Count) throw new BadRequestException("Invalid Order value");

            tasklists.Remove(taskListEntity);
            tasklists.Insert(taskListToPatch.Order - 1, taskList);

            for (int i = 0; i < tasklists.Count; i++)
            {
                tasklists[i].Order = i + 1;
            }

            await _repository.Save();

        }

        public async Task<bool> IsMemberInProject(Guid projectId, string userId)
        {
            var user = await _repository.Member.GetByCondition(x => x.UserId.Equals(userId) && x.ProjectId.Equals(projectId), false).FirstOrDefaultAsync() ?? throw new BadRequestException($"Can not find member with userid {userId}");

            if (user == null)
            {
                return false;
            }
            else return true;
        }

    }
}
