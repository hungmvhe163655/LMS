using Entities.Models;

namespace Contracts.Interfaces
{
    public interface ITaskRepository
    {
        Task DeleteTask(Tasks task);
        Task UpdateTask(Tasks task);
        Task AddNewTask(Tasks task);
        IQueryable<Tasks> GetTasksWithProjectId(Guid projectId, bool check);
        IQueryable<Tasks> GetTasksWithTaskListId(Guid taskListId, bool check);
        IQueryable<Tasks> GetTaskWithId(Guid id, bool track);
    }
}
