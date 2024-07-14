using Entities.Models;

namespace Contracts.Interfaces
{
    public interface ITaskListRepository : IRepositoryBase<TaskList>
    {
        Task<IEnumerable<TaskList>> GetTaskList(Guid projectId, bool trackChanges);
        Task DeleteTaskList(TaskList taskList);
        Task UpdateTaskList(TaskList taskList);
        Task AddNewTaskList(TaskList taskList);
    }
}
