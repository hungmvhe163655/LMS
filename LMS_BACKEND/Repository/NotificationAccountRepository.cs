using Contracts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects.RequestParameters;
using Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class NotificationAccountRepository : RepositoryBase<NotificationAccount>, INotificationAccountRepository
    {
        public NotificationAccountRepository(DataContext context) : base(context)
        {
        }
        public IQueryable<NotificationAccount> GetNotificationsForAccount(NotificationParameters param, bool track)
        {
            return param.Read ? GetByCondition(x => x.AccountId.Equals(param.UserId), track).Include(y => y.Notification).OrderByDescending(y => y.Notification.CreatedDate).FilterNotificationAccount(param).Skip((param.PageNumber - 1) * param.PageSize).Take(param.PageSize)
                              : GetByCondition(x => x.AccountId.Equals(param.UserId) && !x.IsRead, track).Include(y => y.Notification).OrderByDescending(y => y.Notification.CreatedDate).FilterNotificationAccount(param).Skip((param.PageNumber - 1) * param.PageSize).Take(param.PageSize);

        }
    }
}
