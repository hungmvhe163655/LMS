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

        public News GetNewsById(Guid id, bool trackChanges) => GetByCondition(n => n.Id.Equals(id), trackChanges)
            .SingleOrDefault();

        public async Task<PagedList<News>> GetNewsAsync(NewsRequestParameters parameters, bool trackChanges)
        {
            var news = await FindAll(trackChanges).FilterNews(parameters.minCreatedDate, parameters.maxCreatedDate).Search(parameters)
                .OrderBy(n => n.CreatedDate)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges).FilterNews(parameters.minCreatedDate, parameters.maxCreatedDate).Search(parameters)
                .CountAsync();

            return new PagedList<News>(news, count, parameters.PageNumber, parameters.PageSize);
        }
    }
}
