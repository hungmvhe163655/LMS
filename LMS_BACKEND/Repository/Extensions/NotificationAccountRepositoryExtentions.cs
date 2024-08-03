using Entities.Models;
using Shared.DataTransferObjects.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class NotificationAccountRepositoryExtentions
    {
        public static IQueryable<NotificationAccount> FilterNotificationAccount(this IQueryable<NotificationAccount> query, NotificationParameters param)
        {
            var hold = param.NotificationType == null
                  ? query
                  : query
                  .Where(x => x.Notification.NotificationType.ToLower()
                  .Equals(param.NotificationType.ToLower()));

            return hold;
        }
    }
}
