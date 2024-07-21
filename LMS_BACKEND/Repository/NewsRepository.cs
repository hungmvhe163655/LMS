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

        public async Task<News> GetNews(Guid id, bool trackChanges)
        {
            return await FindAll(trackChanges).Where(n => n.Id.Equals(id)).Include(x => x.CreatedByNavigation).FirstAsync();
        }

        public async Task<PagedList<News>> GetNewsAsync(NewsRequestParameters parameters, bool trackChanges)
        {
            var news = await FindAll(trackChanges)
                .Include(n => n.NewsFiles)
                .Include(n => n.CreatedByNavigation)
                .FilterNews(parameters.minCreatedDate, parameters.maxCreatedDate)
                .Search(parameters)
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
