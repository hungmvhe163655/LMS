namespace Contracts.Interfaces
{
    public interface IRepositoryManager
    {
        IAccountRepository account { get; }
        INewsRepository news { get; }
        INotificationRepository notification { get; }
        IStudentDetailRepository studentDetail { get; }
        IFileRepository file { get; }
        IFolderRepository folder { get; }
        IFolderClosureRepository folderClosure { get; }
        IScheduleRepository schedule { get; }
        Task Save();
    }
}
