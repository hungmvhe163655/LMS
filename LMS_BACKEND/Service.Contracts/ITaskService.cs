using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskResponseModel>> GetTasksWithProjectId(Guid projectId);
        Task<TaskResponseModel> GetTaskByID(Guid id);
        Task CreateTask(TaskCreateRequestModel model);
        Task EditTask(TaskUpdateRequestModel model);
        Task DeleteTask(Guid id);
    }
}
