using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
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
    public class TaskListService: ITaskListService
    {
        private readonly IRepositoryManager _repository;

        private readonly IMapper _mapper;

        public TaskListService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repository = repositoryManager;

            _mapper = mapper;
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
            var hold = _mapper.Map<TaskList>(model);

            await _repository.taskList.UpdateTaskList(hold);

            await _repository.Save();
        }
        public async Task<IEnumerable<TaskListResponseModel>> GetTaskList(Guid projectId)
        {
            var hold = await _repository.taskList.GetTaskList(projectId, false);
            if (hold == null) throw new BadRequestException($"Project {projectId} have no task list");
            var result = _mapper.Map<IEnumerable< TaskListResponseModel>>(hold);
            return result;
        }

    }
}
