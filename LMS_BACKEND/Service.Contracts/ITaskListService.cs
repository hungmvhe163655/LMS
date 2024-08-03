using Entities.Models;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface ITaskListService
    {
        Task<IEnumerable<TaskListResponseModel>> GetTaskListByProject(Guid projectId);
        Task<TaskListResponseModel> GetTaskListById(Guid taskListId);
        Task<TaskListResponseModel> CreateTaskList(CreateTaskListRequestModel model);
        Task UpdateTaskList(UpdateTaskListRequestModel model);
        Task DeleteTaskList(Guid tasklistId);
        Task<(TaskListUpdateRequestModel taskListToPatch, TaskList taskListEntity)> GetTaskListForPatch(Guid projectId, Guid taskListId);
        Task SaveChangesForPatch(TaskListUpdateRequestModel taskListToPatch, TaskList taskListEntity, string userId);
    }
}
