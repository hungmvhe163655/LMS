using Contracts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.DataTransferObjects.RequestParameters;

namespace Repository
{
    public class NewsRepository : RepositoryBase<News>, INewsRepository
    {
        public NewsRepository(DataContext context) : base(context)
        {
        }

        public News GetNews(Guid id, bool trackChanges)
        {
            return FindAll(trackChanges).Where(n => n.Id.Equals(id)).First();
        }

        public async Task<PagedList<News>> GetNewsAsync(NewsRequestParameters parameters, bool trackChanges)
        {
            var news = await FindAll(trackChanges).FilterNews(parameters.minCreatedDate, parameters.maxCreatedDate).Search(parameters)
                .FilterNews(parameters.minCreatedDate, parameters.maxCreatedDate)
                .Sort(parameters.OrderBy)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges).FilterNews(parameters.minCreatedDate, parameters.maxCreatedDate).Search(parameters)
                .CountAsync();

            return new PagedList<News>(news, count, parameters.PageNumber, parameters.PageSize);
        }
    }
}
