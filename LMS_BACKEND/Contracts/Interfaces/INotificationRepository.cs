using Entities.Models;

namespace Contracts.Interfaces
{
    public interface INotificationRepository : IRepositoryBase<Notification>
    {
        Task<bool> saveNotification(Notification notification);
    }
}
