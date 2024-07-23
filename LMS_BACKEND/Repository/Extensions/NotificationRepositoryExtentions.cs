using Entities.Models;
using Repository.Extensions.Utility;
using Shared.DataTransferObjects.RequestParameters;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class NotificationRepositoryExtentions
    {
        public static IQueryable<Notification> FilterNotification(this IQueryable<Notification> query, NotificationParameters param)
        {
            var hold = param.NotificationType == null
                  ? query
                  : query
                  .Where(x => x.NotificationType.ToLower()
                  .Equals(param.NotificationType.ToLower()));

            return hold;
        }
        public static IQueryable<Notification> Sort(this IQueryable<Notification> query, NotificationParameters param)
        {
            if (param.OrderBy == null) return query;

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Notification>(param.OrderBy);

            if (string.IsNullOrWhiteSpace(param.OrderBy) || string.IsNullOrWhiteSpace(orderQuery))

                return query.OrderBy(n => n.CreatedDate);

            return query.OrderBy(orderQuery);
        }
    }
}
