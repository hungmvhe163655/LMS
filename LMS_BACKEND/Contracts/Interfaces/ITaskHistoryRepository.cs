using Entities.Models;

namespace Contracts.Interfaces
{
    public interface ITaskHistoryRepository
    {
        Task AddTaskHistory(TaskHistory task);
        void DeleteTaskHistory(Guid taskId);
    }
}
