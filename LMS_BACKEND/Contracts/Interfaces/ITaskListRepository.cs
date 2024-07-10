using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface ITaskListRepository: IRepositoryBase<TaskList>
    {
        Task<IEnumerable<TaskList>> GetTaskList(Guid projectId, bool trackChanges);
        Task DeleteTaskList(TaskList taskList);
        Task UpdateTaskList(TaskList taskList);
        Task AddNewTaskList(TaskList taskList);
    }
}
