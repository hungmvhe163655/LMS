using Contracts.Interfaces;
using Entities.Models;

namespace Repository
{
    public class TaskRepository : RepositoryBase<Tasks>, ITaskRepository
    {
        public TaskRepository(DataContext context) : base(context)
        {
        }
        public IQueryable<Tasks> GetTaskWithId(Guid id, bool track) => GetByCondition(x => x.Id.Equals(id), track);
        public async Task DeleteTask(Tasks task) => await DeleteWithConcurrencyAsync(task);

        public async Task UpdateTask(Tasks task) => await UpdateWithConcurrencyAsync(task);

        public async Task AddNewTask(Tasks task) => await CreateAsync(task);

        public IQueryable<Tasks> GetTasksWithProjectId(Guid projectId, bool check) => FindAll(check).Where(x => x.ProjectId.Equals(projectId));

        public IQueryable<Tasks> GetTasksWithTaskListId(Guid taskListId, bool check) => FindAll(check).Where(x => x.TaskListId.Equals(taskListId));

    }
}
