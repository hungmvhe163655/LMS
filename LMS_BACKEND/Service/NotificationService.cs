﻿using Contracts.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.SignalR;
using Service.Contracts;
using Servive.Hubs;
using Shared.DataTransferObjects.RequestParameters;
using Shared.GlobalVariables;

namespace Service
{
    public class NotificationService : INotificationService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IHubContext<NotificationHub> _hubContext;
        public NotificationService(IRepositoryManager repositoryManager, IHubContext<NotificationHub> hub)
        {
            _repositoryManager = repositoryManager;
            _hubContext = hub;
        }

        public async Task<Notification> CreateNotification(string title, string content, string type, string createUserId, string group)
        {
            var hold = new Notification { Id = Guid.NewGuid(), Title = title, Content = content, NotificationType = MAPPARAM.GetNotificationTypeValue(type), CreatedBy = createUserId, Url = "lmao.com" };//sua cho nay
            await _repositoryManager.notification.saveNotification(hold);
            await _repositoryManager.Save();
            await _hubContext.Clients.Groups(group).SendAsync("ReceiveNotification", hold);
            return hold;
        }

        public async Task<IEnumerable<Notification>> GetAllNotifications(RequestParameters request)
        {
            return await _repositoryManager.notification.GetPagedAsync(request, false);
        }

        public async Task<Notification> GetNotification(string id)
        {
            var result = await _repositoryManager.notification.GetByConditionAsync(entity => entity.Id.Equals(id), false);
            return result.First();
        }
    }
}
