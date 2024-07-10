using Contracts.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TaskHistoryRepository : RepositoryBase<TaskHistory>, ITaskHistoryRepository
    {
        public TaskHistoryRepository(DataContext context) : base(context)
        {
        }

        public async Task AddTaskHistory(TaskHistory task)
        {
            await CreateAsync(task);
        }
        public void DeleteTaskHistory(Guid taskId)
        {
            var hold = GetByCondition(x => x.TaskGuid.Equals(taskId), false);

            DeleteRange(hold);
        }
    }
}
