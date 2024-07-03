using Entities.Models;
using Shared.DataTransferObjects.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositoryNewsExtensions
    {
        public static IQueryable<News> FilterNews(this IQueryable<News> news, DateTime minCreatedDate, DateTime maxCreatedDate) => news.Where(n => (DateTime.Compare(n.CreatedDate, minCreatedDate) > 0 && (DateTime.Compare(n.CreatedDate, maxCreatedDate) < 0)));

        public static IQueryable<News> Search(this IQueryable<News> news, NewsRequestParameters parameters)
        {
            if (string.IsNullOrWhiteSpace(parameters.SearchTerm ?? "")) return news;

            var lowerCaseTerm = parameters.SearchTerm == null ? "" : parameters.SearchTerm.Trim().ToLower();

            if(parameters.SearchByContent) return news.Where(n => n.Content != null && n.Content.ToLower().Contains(lowerCaseTerm));

            return news.Where(n => n.Title.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<News> Sort(this IQueryable<News> news, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return news.OrderBy(n => n.CreatedDate);

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfor = typeof(News).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfor.FirstOrDefault(ni =>
                    ni.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrWhiteSpace(orderQuery))
                return news.OrderBy(n => n.CreatedDate);

            //return news.OrderBy(orderQuery);
            return news;
        }
    }
}
