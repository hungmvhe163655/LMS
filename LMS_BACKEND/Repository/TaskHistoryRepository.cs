using Contracts.Interfaces;
using Entities.Models;

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
