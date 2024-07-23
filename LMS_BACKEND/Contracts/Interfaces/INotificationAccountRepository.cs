using Entities.Models;
using Shared.DataTransferObjects.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface INotificationAccountRepository : IRepositoryBase<NotificationAccount>
    {
        IQueryable<NotificationAccount> GetNotificationsForAccount(NotificationParameters param, bool track);
    }
}
