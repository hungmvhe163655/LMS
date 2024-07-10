using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        public async Task CreateTask(TaskCreateRequestModel model)
        {
            var hold = _mapper.Map<Tasks>(model);

            var hold_user = await
                _repository
                .account
                .GetByCondition(x => x.Id.Equals(model.CreatedBy), true)
                .Include(s => s.Members.Where(y => y.UserId.Equals(model.CreatedBy) && y.ProjectId.Equals(model.ProjectId)))
                .ThenInclude(z => z.Project)
                .FirstAsync() ?? throw new BadRequestException("Created by user id is not existed");

            if (hold_user.Members.IsNullOrEmpty()) throw new Exception("lamao");

            if (hold_user.Members.First().Project == null) throw new Exception("Lamao");

            hold.Id = Guid.NewGuid();

            hold.CreatedDate = DateTime.Now;

            var hold_version = _mapper.Map<TaskHistory>(hold);

            hold_version.Id = Guid.NewGuid();

            hold_version.EditDate = DateTime.Now;

            hold_user.TaskHistories.Add(hold_version);

            await _repository.task.AddNewTask(hold);

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
        public async Task DeleteTask(Guid id)
        {
            var hold = _repository.task.GetTaskWithId(id, false).First();

            await _repository.task.DeleteTask(hold);

            await _repository.Save();
        }

        public async Task<TaskResponseModel> GetTaskByID(Guid id)
        {
            return _mapper.Map<TaskResponseModel>(await _repository.task.GetTaskWithId(id, false).FirstAsync());
        }
    }
}
