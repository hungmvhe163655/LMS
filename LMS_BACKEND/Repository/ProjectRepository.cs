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
            var projects = await GetByCondition(p => p.Members.Any(m => m.UserId != null && m.UserId.Equals(userId)) && p.ProjectStatus.Equals(PROJECT_STATUS.ONGOING), false)
                .Include(p => p.Members)
                .FilterProjects(parameters.minCreatedDate, parameters.maxCreatedDate)
                .Search(parameters)
                .Sort(parameters.OrderBy)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChange).FilterProjects(parameters.minCreatedDate, parameters.maxCreatedDate).Search(parameters)
                .CountAsync();

            return new PagedList<Project>(projects, count, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<Project>> GetProjectsAsync(ProjectRequestParameters parameters, bool trackChange)
        {
            var projects = await FindAll(trackChange).FilterProjects(parameters.minCreatedDate, parameters.maxCreatedDate)
                .Search(parameters)
                .Sort(parameters.OrderBy)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChange).FilterProjects(parameters.minCreatedDate, parameters.maxCreatedDate).Search(parameters)
                .CountAsync();

            return new PagedList<Project>(projects, count, parameters.PageNumber, parameters.PageSize);
        }

    }
}
