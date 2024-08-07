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

        public async Task SendProjectNotification(string UserId, NotificationResponseModel notification)
        {
            await Clients.Group(UserId).SendAsync("ReceiveUserNotification", notification);
        }

        public async Task AddToUserGroup(string UserId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, UserId);
            Console.WriteLine($"Client {Context.ConnectionId} added to group {UserId}");
        }

        public async Task RemoveFromUserGroup(string UserId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, UserId);
            Console.WriteLine($"Client {Context.ConnectionId} removed from group {UserId}");
        }
    }
}
