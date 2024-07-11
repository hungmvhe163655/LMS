using Entities.Models;
using Shared.DataTransferObjects.RequestParameters;

namespace Service.Contracts
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetAllNotifications(RequestParameters model);
        Task<Notification> GetNotification(string id);
        Task<Notification> CreateNotification(string title, string content, int type, string createUserId, string group);
    }
}
