using Entities.Models;
using Repository.Extensions.Utility;
using Shared.DataTransferObjects.RequestParameters;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class FilesRepositoryExtentions
    {
        public static IQueryable<Files> Sort(this IQueryable<Files> data, string? orderByQueryString)
        {
            if (string.IsNullOrEmpty(orderByQueryString)) return data.OrderBy(n => n.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<News>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderByQueryString) || string.IsNullOrWhiteSpace(orderQuery))

                return data.OrderBy(n => n.Name);

            return data.OrderBy(orderQuery);
        }
    }
}
