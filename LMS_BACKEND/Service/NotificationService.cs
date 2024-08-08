using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using Servive.Hubs;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using Shared.GlobalVariables;

namespace Service
{
    public class NotificationService : INotificationService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IMapper _mapper;
        public NotificationService(IRepositoryManager repositoryManager, IHubContext<NotificationHub> hub, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
            _hubContext = hub;
        }

        public async Task<NotificationResponseModel> CreateNotification(CreateNotificationRequestModel model)
        {
            var hold = new Notification { ProjectId = Guid.Parse(model.Group ?? ""), Id = Guid.NewGuid(), Title = model.Title, Content = model.Content, NotificationType = MAPPARAM.GetNotificationTypeValue(model.Type), CreatedBy = model.CreateUserId, Url = "lmao.com" };//sua cho nay

            if (hold.NotificationType.Equals(NOTIFICATION_TYPE.PROJECT))
            {
                var hold_members = await
                    _repositoryManager
                    .Member
                    .GetByCondition(x => x.ProjectId.Equals(model.ProjectId), true)
                    .Include(y => y.User)
                    .ToListAsync() ?? throw new BadRequestException("Invalid project ID");

                foreach (var item in hold_members)
                {
                    if (item.User == null) continue;

                    item.User.NotificationsAccounts.Add(new NotificationAccount { NotificationId = hold.Id, AccountId = item.User.Id, IsRead = false });

                    await _hubContext.Clients.Groups(item.UserId).SendAsync("ReceiveUserNotification", _mapper.Map<NotificationResponseModel>(hold));
                }
            }

            await _repositoryManager.Notification.SaveNotification(hold);

            await _repositoryManager.Save();

            if (!hold.NotificationType.Equals(NOTIFICATION_TYPE.PROJECT)) await _hubContext.Clients.All.SendAsync("ReceiveSystemNotification", _mapper.Map<NotificationResponseModel>(hold));

            return _mapper.Map<NotificationResponseModel>(hold);
        }

        public async Task<NotificationResponseModel> CreateNotificationForProject(Guid projectId, string title, string content, string user)
        {
            var hold = new Notification { ProjectId = projectId, Id = Guid.NewGuid(), Title = title, Content = content, NotificationType = NOTIFICATION_TYPE.PROJECT, CreatedBy = user, Url = $"projects/{projectId}" };

            var hold_members = await
                _repositoryManager
                .Member
                .GetByCondition(x => x.ProjectId.Equals(projectId) && x.IsValidTeamMember, true)
                .ToListAsync() ?? throw new BadRequestException("Invalid project ID");

            foreach (var item in hold_members)
            {
                hold.NotificationsAccounts.Add(new NotificationAccount { NotificationId = hold.Id, AccountId = item.UserId, IsRead = false });
            }

            await _repositoryManager.Notification.SaveNotification(hold);

            await _repositoryManager.Save();

            foreach (var item in hold_members) await _hubContext.Clients.Groups(item.UserId).SendAsync("ReceiveUserNotification", _mapper.Map<NotificationResponseModel>(hold));

            return _mapper.Map<NotificationResponseModel>(hold);
        }

        public async Task<PagedList<NotificationResponseModel>> GetPagedNotifications(NotificationParameters param)
        {
            var hold = await _repositoryManager.NotificationAccount.GetNotificationsForAccount(param, false).ToListAsync();

            var hold_noti = new List<Notification>();

            foreach (var item in hold) hold_noti.Add(item.Notification);

            return new PagedList<NotificationResponseModel>(_mapper.Map<List<NotificationResponseModel>>(hold_noti), hold_noti.Count, param.PageNumber, param.PageSize);
        }

        public async Task<IEnumerable<Notification>> GetAllNotifications(RequestParameters request)
        {
            return await _repositoryManager.Notification.GetPagedAsync(request, false);
        }

        public async Task<NotificationResponseModel?> GetNotification(Guid id)
        {
            return _mapper.Map<NotificationResponseModel>(await _repositoryManager.Notification.GetByCondition(entity => entity.Id.Equals(id), false).FirstOrDefaultAsync());
        }

        public async Task MarkNotificationAsRead(string userId, Guid notificationId)
        {
            var user = await
                _repositoryManager
                .Account
                .GetByCondition(x => x.Id.Equals(userId), false)
                .FirstOrDefaultAsync()
                ?? throw new BadRequestException("Invalid User Id");

            var hold = await
                _repositoryManager
                .NotificationAccount
                .GetByCondition(x => x.AccountId.Equals(userId) && x.NotificationId.Equals(notificationId), true)
                .FirstOrDefaultAsync()
                ?? throw new BadRequestException("Invalid Notification Id");

            var hold_noti = await
                _repositoryManager
                .Notification
                .GetByCondition(x => x.Id.Equals(notificationId), true)
                .FirstOrDefaultAsync() ?? throw new BadRequestException("Invalid Notification Id");

            if (hold_noti.NotificationType.Equals(NOTIFICATION_TYPE.PROJECT))

                hold.IsRead = true;

            if (hold_noti.NotificationType.Equals(NOTIFICATION_TYPE.SYSTEM))
                if (hold == null)
                    hold_noti.NotificationsAccounts.Add(new NotificationAccount { AccountId = user.Id, NotificationId = hold_noti.Id, IsRead = true });
                else
                    hold.IsRead = true;

            await _repositoryManager.Save();

        }

        public async Task NotifyProjectMembers(string projectId, NotificationResponseModel notification)
        {
            await _hubContext.Clients.Group(projectId).SendAsync("ReceiveProjectNotification", notification);
        }

        public async Task NotifyAllUsers(NotificationResponseModel notification)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveSystemNotification", notification);
        }
    }
}
