using Contracts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.DataTransferObjects.RequestParameters;
using Shared.GlobalVariables;

namespace Repository
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(DataContext context) : base(context)
        {
        }

        public async Task<PagedList<Project>> GetOngoingProjectAsync(string userId, ProjectRequestParameters parameters, bool trackChange)
        {
            var projects = await GetByCondition(p => p.Members.Any(m => m.UserId != null && m.UserId.Equals(userId)) && p.ProjectStatus.Equals(PROJECT_STATUS.ONGOING), trackChange)
                .Include(p => p.Members)
                .Include(p => p.TaskLists)
                .ThenInclude(t => t.Tasks)
                .FilterProjects(parameters.MinCreatedDate, parameters.MaxCreatedDate, parameters.ProjectStatusFilter, parameters.ProjectTypeId)
                .Search(parameters)
                .Sort(parameters.OrderBy)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChange).FilterProjects(parameters.MinCreatedDate, parameters.MaxCreatedDate).Search(parameters)
                .CountAsync();

            return new PagedList<Project>(projects, count, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<Project>> GetProjectAsync(string userId, ProjectRequestParameters parameters, bool trackChange)
        {
            var projects = await GetByCondition(p => p.Members.Any(m => m.UserId != null && m.UserId.Equals(userId)), trackChange)
                .Include(p => p.Members)
                .Include(p => p.TaskLists)
                .ThenInclude(t => t.Tasks)
                .FilterProjects(parameters.MinCreatedDate, parameters.MaxCreatedDate, parameters.ProjectStatusFilter, parameters.ProjectTypeId)
                .Search(parameters)
                .Sort(parameters.OrderBy)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChange).FilterProjects(parameters.MinCreatedDate, parameters.MaxCreatedDate).Search(parameters)
                .CountAsync();

            return new PagedList<Project>(projects, count, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<Project>> GetAllProjectsAsync(ProjectRequestParameters parameters, bool trackChange)
        {
            var projects = await FindAll(trackChange).FilterProjects(parameters.MinCreatedDate, parameters.MaxCreatedDate)
                .Include(p => p.TaskLists)
                .ThenInclude(t => t.Tasks)
                .Search(parameters)
                .Sort(parameters.OrderBy)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChange).FilterProjects(parameters.MinCreatedDate, parameters.MaxCreatedDate).Search(parameters)
                .CountAsync();

            return new PagedList<Project>(projects, count, parameters.PageNumber, parameters.PageSize);
        }

    }
}
