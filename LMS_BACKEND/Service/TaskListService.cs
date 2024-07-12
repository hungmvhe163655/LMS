using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .taskList
                .GetByCondition(x => x.Id.Equals(taskListId), false)
                .Include(y => y.Tasks)
                .ThenInclude(z => z.AssignedToUser)
                .Include(y => y.Tasks)
                .ThenInclude(z => z.TaskStatus)
                .ToListAsync();

            if (hold == null) throw new BadRequestException($"Can not found task list with id {taskListId}");
            var result = _mapper.Map<TaskListResponseModel>(hold.FirstOrDefault());
            return result;
        }

        public async Task CreateTaskList(CreateTaskListRequestModel model)
        {
            var hold = _mapper.Map<TaskList>(model);

            hold.Id = Guid.NewGuid();

            await _repository.taskList.AddNewTaskList(hold);

            await _repository.Save();
        }


        public async Task UpdateTaskList(UpdateTaskListRequestModel model)
        {
            var hold = _repository.taskList.GetByCondition(x => x.Id.Equals(model.Id), true).FirstOrDefault();
            if (hold == null) throw new BadRequestException($"Can not find task list with id {model.Id}");
            var count = _repository.task.GetTasksWithTaskListId(hold.Id, false).Count();
            if (count > model.MaxTasks) throw new BadRequestException($"Max task must greater than number current task on list");
            
            _mapper.Map(model, hold);
            await _repository.Save();
        }
        public async Task<IEnumerable<TaskListResponseModel>> GetTaskListByProject(Guid projectId)
        {
            var hold = await
                _repository
                .taskList
                .GetByCondition(x => x.ProjectId.Equals(projectId), false)
                .Include(y => y.Tasks)
                .ThenInclude(z => z.AssignedToUser)
                .Include(y => y.Tasks)
                .ThenInclude(z => z.TaskStatus)
                .ToListAsync();

            if (hold == null) throw new BadRequestException($"Project {projectId} have no task list");
            var result = _mapper.Map<IEnumerable<TaskListResponseModel>>(hold);
            return result;
        }

        public async Task DeleteTaskList(Guid taskListId)
        {
            var count = _repository.task.GetTasksWithTaskListId(taskListId, false).Count();
            if (count > 0) throw new BadRequestException("Can not delete task list have tasks inside");
            var hold = _repository.taskList.GetByCondition(x => x.Id.Equals(taskListId), false).FirstOrDefault();
            if (hold == null) throw new BadRequestException($"Can not find task list with id {taskListId}");
            _repository.taskList.Delete(hold);
            await _repository.Save();
        }

    }
}
