namespace Service.Contracts
{
    public interface IServiceManager
    {
        IAccountService AccountService { get; }
        IAuthenticationService AuthenticationService { get; }
        IMailService MailService { get; }
        IFileService FileService { get; }
        INewsService NewsService { get; }
        INotificationService NotificationService { get; }
        IScheduleService ScheduleService { get; }
        ITaskService TaskService { get; }
        ITaskListService TaskListService { get; }
        IReportService ReportService { get; }
        IProjectService ProjectService { get; }
        IMemberService MemberService { get; }
        IDeviceService DeviceService { get; }
        ICommentService CommentService { get; }
    }
}
