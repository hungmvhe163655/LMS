using Entities.Models;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface ITaskListService
    {
        Task<IEnumerable<TaskListResponseModel>> GetTaskListByProject(Guid projectId);
        Task<TaskListResponseModel> GetTaskListById(Guid taskListId);
        Task<TaskList> CreateTaskList(CreateTaskListRequestModel model);
        Task UpdateTaskList(UpdateTaskListRequestModel model);
        Task DeleteTaskList(Guid tasklistId);
    }
}
