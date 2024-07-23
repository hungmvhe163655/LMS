using Entities.Models;
using Shared.DataTransferObjects.RequestParameters;

namespace Contracts.Interfaces
{
    public interface IProjectRepository : IRepositoryBase<Project>
    {
        Task<PagedList<Project>> GetAllProjectsAsync(ProjectRequestParameters parameters, bool trackChanges);
        Task<PagedList<Project>> GetOngoingProjectAsync(string userId, ProjectRequestParameters parameters, bool trackChanges);
        Task<PagedList<Project>> GetProjectAsync(string userId, ProjectRequestParameters parameters, bool trackChanges);
    }
}
