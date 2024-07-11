using Contracts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TaskListRepository : RepositoryBase<TaskList>, ITaskListRepository
    {
        public TaskListRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TaskList>> GetTaskList(Guid projectId, bool trackChanges)
        {
            var hold = await FindAll(trackChanges).Where(n => n.ProjectId.Equals(projectId)).Include(t => t.Tasks).ThenInclude(x => x.TaskStatus).ToListAsync();
            return hold;
        }

        public async Task AddNewTaskList(TaskList taskList) => await CreateAsync(taskList);

        public async Task DeleteTaskList(TaskList taskList) => await DeleteWithConcurrencyAsync(taskList);

        public async Task UpdateTaskList(TaskList taskList) => await UpdateWithConcurrencyAsync(taskList);
    }
}
