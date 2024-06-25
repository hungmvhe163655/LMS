using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface INotificationService
    {

        Task<PageModel<Notification>> GetAllNotifications(int page,int pagesize);  
        Task<Notification> GetNotification(string id);
        Task<Notification> CreateNotification(string title, string content, int type, string createUserId, string group);
    }
}
