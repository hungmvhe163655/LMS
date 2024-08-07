using Entities.Models;
using Microsoft.AspNetCore.SignalR;
using Shared.DataTransferObjects.ResponseDTO;

namespace Servive.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendSystemNotification(NotificationResponseModel notification)
        {
            await Clients.All.SendAsync("ReceiveSystemNotification", notification);
        }

        public async Task SendProjectNotification(string projectId, NotificationResponseModel notification)
        {
            await Clients.Group(projectId).SendAsync("ReceiveProjectNotification", notification);
        }

        public async Task AddToProjectGroup(string projectId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, projectId);
        }

        public async Task RemoveFromProjectGroup(string projectId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, projectId);
        }
    }
}
