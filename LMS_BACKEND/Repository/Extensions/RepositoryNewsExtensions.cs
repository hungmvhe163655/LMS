using Entities.Models;
using Repository.Extensions.Utility;
using Shared.DataTransferObjects.RequestParameters;
using System.Linq.Dynamic.Core;
using System.Text;

namespace Repository.Extensions
{
    public static class RepositoryNewsExtensions
    {
        public static IQueryable<News> FilterNews(this IQueryable<News> news, DateTime minCreatedDate, DateTime maxCreatedDate) => news.Where(n => (DateTime.Compare(n.CreatedDate, minCreatedDate) > 0 && (DateTime.Compare(n.CreatedDate, maxCreatedDate) < 0)));

        public static IQueryable<News> Search(this IQueryable<News> news, NewsRequestParameters parameters)
        {
            if (string.IsNullOrWhiteSpace(parameters.SearchTerm ?? "")) return news;

            var lowerCaseTerm = parameters.SearchTerm == null ? "" : parameters.SearchTerm.Trim().ToLower();

            if (parameters.SearchByContent) return news.Where(n => n.Content != null && n.Content.ToLower().Contains(lowerCaseTerm));

            return news.Where(n => n.Title.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<News> Sort(this IQueryable<News> news, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return news.OrderBy(n => n.CreatedDate);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<News>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return news.OrderBy(n => n.CreatedDate);

            return news.OrderBy(orderQuery);
        }
    }
}
