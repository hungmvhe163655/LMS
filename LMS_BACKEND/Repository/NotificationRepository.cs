using Contracts.Interfaces;
using Entities.Models;
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
                .FilterNotification(param)
                .Sort(param)
                .Skip((param.PageNumber - 1) * param.PageSize)
                .Take(param.PageSize);
        }
        public async Task<bool> saveNotification(Notification notification)
        {
            try
            {
                notification.NotificationsAccounts
                       .Add(
                    new NotificationAccount
                    {
                        AccountId = notification.CreatedBy,
                        IsRead = false,
                        NotificationId = notification.Id
                    });
                await CreateAsync(notification);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
