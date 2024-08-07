﻿using Entities.Models;

namespace Contracts.Interfaces
{
    public interface ITaskHistoryRepository
    {
        Task AddTaskHistory(TaskHistory task);
        void DeleteTaskHistory(Guid taskId);
        IQueryable<TaskHistory> GetTaskHistoriesWithTaskId(Guid taskId, bool track);
    }
}
