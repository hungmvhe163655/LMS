using Amazon.S3;
using AutoMapper;
using Contracts.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Servive.Hubs;
using System.Net.Mail;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        //add more here
        private readonly Lazy<IAccountService> _accountService;

        private readonly Lazy<IAuthenticationService> _authenticationService;

        private readonly Lazy<IMailService> _mailService;

        private readonly Lazy<INewsService> _newsService;

        private readonly Lazy<IFileService> _fileService;

        private readonly Lazy<INotificationService> _notificationService;

        private readonly Lazy<IFolderService> _folderService;

        private readonly Lazy<IScheduleService> _scheduleService;

        private readonly Lazy<ITaskService> _taskService;
        private readonly Lazy<ITaskListService> _taskListService;
        private readonly Lazy<IProjectService> _projectService;
        private readonly Lazy<IMemberService> _memberService;
        //
        public ServiceManager(
            IRepositoryManager repositoryManager,
            ILoggerManager logger,
            IMapper mapper,
            UserManager<Account> userManager,
            RoleManager<IdentityRole> roleManager,
            SmtpClient client,
            IConfiguration configuration,
            IMemoryCache memoryCache,
            IAmazonS3 clients3,
            IHubContext<NotificationHub> notiHub
            )
        {
            _accountService = new Lazy<IAccountService>(() => new AccountService(repositoryManager, logger, mapper, userManager, roleManager));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration, roleManager, repositoryManager));
            _mailService = new Lazy<IMailService>(() => new MailService(logger, client, userManager, memoryCache, repositoryManager));
            _newsService = new Lazy<INewsService>(() => new NewsService(repositoryManager, mapper));
            _fileService = new Lazy<IFileService>(() => new FileService(clients3, configuration, mapper, repositoryManager));
            _notificationService = new Lazy<INotificationService>(() => new NotificationService(repositoryManager, notiHub));
            _folderService = new Lazy<IFolderService>(() => new FolderService());
            _scheduleService = new Lazy<IScheduleService>(() => new ScheduleService(repositoryManager, mapper));
            _taskService = new Lazy<ITaskService>(() => new TaskService(repositoryManager, mapper));
            _taskListService = new Lazy<ITaskListService>(() => new TaskListService(repositoryManager, mapper));
            _projectService = new Lazy<IProjectService>(() => new ProjectService(repositoryManager, mapper));
            _memberService = new Lazy<IMemberService>(() => new MemberService(repositoryManager, mapper));
        }
        public IAccountService AccountService => _accountService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IMailService MailService => _mailService.Value;
        public INewsService NewsService => _newsService.Value;
        public IFileService FileService => _fileService.Value;
        public INotificationService NotificationService => _notificationService.Value;
        public IScheduleService ScheduleService => _scheduleService.Value;
        public ITaskService TaskService => _taskService.Value;
        public ITaskListService TaskListService => _taskListService.Value;
        public IProjectService ProjectService => _projectService.Value;
        public IMemberService MemberService => _memberService.Value;
    }
}
