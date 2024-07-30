using Entities.Models;
using Repository.Extensions.Utility;
using Shared.DataTransferObjects.RequestParameters;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class FolderRepositoryExtentions
    {
        public static IQueryable<Folder> SortContent(this IQueryable<Folder> data, string? orderByQueryString)
        {
            if (string.IsNullOrEmpty(orderByQueryString)) return data.OrderBy(n => n.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Folder>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderByQueryString) || string.IsNullOrWhiteSpace(orderQuery))

                return data.OrderBy(n => n.CreatedDate);

            return data.OrderBy(orderQuery);
        }
    }
}
