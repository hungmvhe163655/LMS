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
        ITaskRepository task { get; }
        ITaskHistoryRepository taskHistory { get; }
        ITaskListRepository taskList { get; }
        IProjectRepository project { get; }
        IMemberRepository member { get; }
        IProjectStatusRepository projectStatus { get; }
        IProjectTypeRepository projectType { get; }
        Task Save();
    }
}
