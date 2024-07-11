using Contracts.Interfaces;
using Entities.Models;

namespace Repository
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(DataContext context) : base(context)
        {
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
