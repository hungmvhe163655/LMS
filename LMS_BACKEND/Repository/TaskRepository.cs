using Contracts.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TaskRepository : RepositoryBase<Tasks>, ITaskRepository
    {
        public TaskRepository(DataContext context) : base(context)
        {
        }
        public async Task DeleteTask(Tasks task) => await DeleteWithConcurrencyAsync(task);

        public async Task UpdateTask(Tasks task) => await UpdateWithConcurrencyAsync(task);

        public async Task AddNewTask(Tasks task) => await CreateAsync(task);

        public IQueryable<Tasks> GetTasksWithProjectId(Guid projectId, bool check) => FindAll(check).Where(x => x.ProjectId.Equals(projectId));

    }
}
