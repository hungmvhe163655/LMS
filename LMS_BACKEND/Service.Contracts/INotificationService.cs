using Entities.Models;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetAllNotifications(RequestParameters model);
        Task<NotificationResponseModel?> GetNotification(Guid id);
        Task<NotificationResponseModel> CreateNotification(CreateNotificationRequestModel model);
        Task<NotificationResponseModel> CreateNotificationForProject(Guid projectId, string title, string content, string user);
        Task MarkNotificationAsRead(string userId, Guid notificationId);
        Task<PagedList<NotificationResponseModel>> GetPagedNotifications(NotificationParameters param);
    }
}
