namespace Contracts.Interfaces
{
    public interface IRepositoryManager
    {
        IReportRepository Report { get; }
        IAccountRepository Account { get; }
        INewsRepository News { get; }
        INewsFileRepository NewsFile { get; }
        INotificationRepository Notification { get; }
        IStudentDetailRepository StudentDetail { get; }
        IFileRepository File { get; }
        IFolderRepository Folder { get; }
        IFolderClosureRepository FolderClosure { get; }
        IScheduleRepository Schedule { get; }
        ITaskRepository Task { get; }
        ITaskHistoryRepository TaskHistory { get; }
        ITaskListRepository TaskList { get; }
        IProjectRepository Project { get; }
        IMemberRepository Member { get; }
        IProjectTypeRepository ProjectType { get; }
        IDeviceRepository Device { get; }
        INotificationAccountRepository NotificationAccount { get; }
        Task Save();
    }
}
