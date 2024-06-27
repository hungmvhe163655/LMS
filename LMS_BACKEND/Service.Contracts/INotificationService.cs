using Entities;
using Entities.Models;
using Shared.DataTransferObjects.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetAllNotifications(RequestParameters model);
        Task<Notification> GetNotification(string id);
        Task<Notification> CreateNotification(string title, string content, int type, string createUserId, string group);
    }
}
