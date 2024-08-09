using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Contracts;

namespace Service
{
    public class NotificationBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMemoryCache _cache;

        public NotificationBackgroundService(IServiceProvider serviceProvider, IMemoryCache cache)
        {
            _serviceProvider = serviceProvider;
            _cache = cache;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await CheckSchedulesAsync();
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

        private async Task CheckSchedulesAsync()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var serviceManager = scope.ServiceProvider.GetRequiredService<IServiceManager>();

                var dueSchedules = await serviceManager.ScheduleService.GetDueSchedulesAsync();

                foreach (var schedule in dueSchedules)
                {
                    if(_cache.Get(schedule.Id) != null) continue;
                    // can thi sua singalR chua implement voi vi con chua test
                    //await signalRService.SendNotificationAsync(schedule.UserId, "Your schedule is due!");
                    var user = await serviceManager.AccountService.GetUserById(schedule.AccountId ?? "#");

                    if (user != null) await serviceManager.MailService.SendMailToUser(user.Email, "Schedule Notification", "Your schedule is due!");
                    
                    _cache.Set($"Done{schedule.Id}", schedule.Id);
                }
            }
        }
    }
}
