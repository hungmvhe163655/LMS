using AutoMapper;
using Contracts.Interfaces;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task CreateTask(TaskCreateRequestModel model)
        {
            var hold = _mapper.Map<Tasks>(model);

            hold.Id = Guid.NewGuid();

            hold.CreatedDate = DateTime.Now;

            var hold_version = _mapper.Map<TaskHistory>(hold);

            hold_version.Id = Guid.NewGuid();

            hold_version.EditDate = DateTime.Now;

            await _repository.task.AddNewTask(hold);

            await _repository.taskHistory.AddTaskHistory(hold_version);

            await _repository.Save();
        }
        public async Task EditTask(TaskUpdateRequestModel model)
        {
            var hold = _mapper.Map<Tasks>(model);

            var hold_version = _mapper.Map<TaskHistory>(hold);

            hold_version.Id = Guid.NewGuid();

            hold_version.EditDate = DateTime.Now;

            await _repository.task.UpdateTask(hold);

            await _repository.taskHistory.AddTaskHistory(hold_version);

            await _repository.Save();
        }
    }
}
