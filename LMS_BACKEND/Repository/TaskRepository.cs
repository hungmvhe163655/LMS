using Contracts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.DataTransferObjects.RequestParameters;

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

          public async Task<PagedList<Tasks>> GetAllTaskByUser(string userId, TaskRequestParameters parameters, bool check)
        {
            var tasks= await GetByCondition(t => t.AssignedTo.Equals(userId), check)
                .FilterTasks(parameters.startDateFilter,parameters.endDateFilter, parameters.ProjectIdFilter, parameters.TaskStatusFilter)
                .Search(parameters)
                .Sort(parameters.OrderBy)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            var count = await FindAll(check).FilterTasks(parameters.startDateFilter, parameters.endDateFilter).Search(parameters).CountAsync();

            return new PagedList<Tasks>(tasks, count, parameters.PageNumber, parameters.PageSize);
        }
    }
}
