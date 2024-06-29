using Entities.Models;
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

        public static IQueryable<News> Search(this IQueryable<News> news, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return news;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return news.Where(n => n.Title.ToLower().Contains(lowerCaseTerm));
        }
    }
}
