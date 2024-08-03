using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.DataTransferObjects.RequestParameters;

namespace Repository
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(DataContext context) : base(context)
        {
        }
        public IQueryable<Notification> GetNotifications(NotificationParameters param, bool track)
        {
            return FindAll(track)
                .Include(x => x.NotificationsAccounts
                .Where(y => y.AccountId
                .Equals(param.UserId)))
                .FilterNotification(param)
                .Sort(param)
                .Skip((param.PageNumber - 1) * param.PageSize)
                .Take(param.PageSize);
        }
        public async Task<bool> SaveNotification(Notification notification)
        {
            notification.NotificationsAccounts
                   .Add(
                new NotificationAccount
                {
                    AccountId = notification.CreatedBy ?? throw new BadRequestException("Invalid user Id"),
                    IsRead = false,
                    NotificationId = notification.Id
                });
            await CreateAsync(notification);
            return true;
        }
    }
}
