using Entities.Models;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ITaskListService
    {
        Task<IEnumerable<TaskListResponseModel>> GetTaskList(Guid projectId);
        Task CreateTaskList(CreateTaskListRequestModel model);
        Task UpdateTaskList(UpdateTaskListRequestModel model);
    }
}
