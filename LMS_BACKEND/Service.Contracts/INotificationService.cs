using Entities.Models;
using Shared.DataTransferObjects.RequestParameters;

namespace Service.Contracts
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetAllNotifications(RequestParameters model);
        Task<Notification?> GetNotification(Guid id);
        Task<Notification> CreateNotification(string title, string content, string type, string createUserId, string group);
    }
}
