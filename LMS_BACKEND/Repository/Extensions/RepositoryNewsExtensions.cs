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
    }
}
