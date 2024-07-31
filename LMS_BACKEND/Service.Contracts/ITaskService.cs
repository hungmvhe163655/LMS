﻿using Entities.Models;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using Shared.DataTransferObjects.RequestParameters;

namespace Service.Contracts
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskResponseModel>> GetTasksWithProjectId(Guid projectId);
        Task<IEnumerable<TaskResponseModel>> GetTasksWithTaskListId(Guid taskListId);
        Task<TaskResponseModel> GetTaskByID(Guid id);
        Task AssignUserToTask(Guid taskId, string userId, string editor);
        Task<TaskResponseModel> CreateTask(TaskCreateRequestModel model, string hold_user);
        Task EditTask(TaskUpdateRequestModel model, Guid id, string editor);
        Task DeleteTask(Guid id, string userId);
        Task<(TaskUpdateRequestModel taskToPatch, Tasks taskEntity)> GetTaskForPatch(Guid taskListId, Guid taskId);
        Task SaveChangesForPatch(TaskUpdateRequestModel taskToPatch, Tasks taskEntity, string userId);
        Task SaveChangesInTaskListForPatch(TaskUpdateRequestModel taskToPatch, Tasks taskEntity, string userId);
        Task<bool> IsTaskListAvailable(Guid taskListId);
        Task<bool> IsMemberInProject(Guid taskListId, string userId);
        Task<(IEnumerable<TaskResponseModel> tasks, MetaData metaData)> GetTasksByUser(string userId, TaskRequestParameters parameters);
    }
}
