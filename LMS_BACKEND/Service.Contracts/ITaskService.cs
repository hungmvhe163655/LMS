using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskResponseModel>> GetTasksWithProjectId(Guid projectId);
        Task<IEnumerable<TaskResponseModel>> GetTasksWithTaskListId(Guid taskListId);
        Task<TaskResponseModel> GetTaskByID(Guid id);
        Task CreateTask(TaskCreateRequestModel model);
        Task EditTask(TaskUpdateRequestModel model);
        Task DeleteTask(Guid id, string userId);
    }
}
