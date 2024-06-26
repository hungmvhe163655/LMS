﻿using Contracts.Interfaces;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using Servive.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Notification> CreateNotification(string title, string content, int type, string createUserId, string group)
        {
            var hold = new Notification {Id = Guid.NewGuid(), Title = title, Content = content, NotificationTypeId = type, CreatedBy = createUserId ,Url = "lmao.com"};
            await _repositoryManager.notification.saveNotification(hold);
            await _repositoryManager.Save();
            await _hubContext.Clients.Groups(group).SendAsync("ReceiveNotification", hold);
            return hold;
        }

        public async Task<PageModel<Notification>> GetAllNotifications(int page, int pagesize)
        {
            return await _repositoryManager.notification.GetPagedAsync(page, pagesize, false);
        }

        public async Task<Notification> GetNotification(string id)
        {
            var result = await _repositoryManager.notification.GetByConditionAsync(entity => entity.Id.Equals(id), false);
            return result.First();
        }
    }
}
