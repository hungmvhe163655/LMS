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

        //public async Task<IEnumerable<News>> GetNews(bool track) => await FindAll(track).OrderBy(x => x.Title).ToListAsync();
        //public async Task<IEnumerable<News>> GetNewsWithQuery(bool track, NewsRequestParameters parameters)
        //{
        //    if (parameters.SearchTerm != null)
        //    {
        //        var query = FindAll(false).Where(x => x.Title.ToLower().Contains(parameters.SearchTerm.ToLower())).OrderBy(y => y.Title);
        //        return PagedList<News>.ToPagedList(await query.ToListAsync(), parameters.PageNumber, parameters.PageSize);
        //    }
        //    else
        //    {
        //        var query = FindAll(false).OrderBy(y => y.Title);
        //        return PagedList<News>.ToPagedList(await query.ToListAsync(), parameters.PageNumber, parameters.PageSize);
        //    }

        //}
        
        public async Task<PagedList<News>> GetNewsAsync(NewsRequestParameters parameters, bool trackChanges)
        {
            var news = await FindAll(trackChanges).FilterNews(parameters.minCreatedDate, parameters.maxCreatedDate).Search(parameters).OrderBy(n => n.Title).ToListAsync();

            return PagedList<News>.ToPagedList(news, parameters.PageNumber, parameters.PageSize);
        }
    }
}
