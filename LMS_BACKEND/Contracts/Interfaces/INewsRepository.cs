using Entities.Models;
using Shared.DataTransferObjects.RequestParameters;

namespace Contracts.Interfaces
{
    public interface INewsRepository : IRepositoryBase<News>
    {
        Task<PagedList<News>> GetNewsAsync(NewsRequestParameters parameters, bool trackChanges);
        Task<News> GetNews(Guid id, bool trackChanges);
    }
}
