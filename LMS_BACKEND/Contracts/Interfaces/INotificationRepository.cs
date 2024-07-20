using Entities.Models;
using Shared.DataTransferObjects.RequestParameters;

namespace Contracts.Interfaces
{
    public interface INotificationRepository : IRepositoryBase<Notification>
    {
        IQueryable<Notification> GetNotifications(NotificationParameters param, bool track);
        Task<bool> saveNotification(Notification notification);
    }
}
