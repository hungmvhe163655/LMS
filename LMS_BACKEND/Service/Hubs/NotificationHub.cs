using Entities.Models;
using Microsoft.AspNetCore.SignalR;

namespace Servive.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendNotifyToProject(string projectID, Notification noti)
        {
            await Clients.Group(projectID).SendAsync("ReceiveMessage", noti);
        }
        public async Task AddToTeam(string projectID)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, projectID);
        }
        public async Task RemoveFromTeam(string projectID)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, projectID);
        }
    }
}
