using Entities.Models;
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
        Task<(TaskUpdateRequestModel taskToPatch, Tasks taskEntity, Guid oldLitId)> MoveTaskForPatch(Guid taskListId, Guid taskId);
        Task<Guid> SaveChangesForPatch(TaskUpdateRequestModel taskToPatch, Tasks taskEntity, string userId);
        Task<bool> IsTaskListAvailable(Guid taskListId);
        Task<bool> IsMemberInProject(Guid taskListId, string userId);

    }
}
