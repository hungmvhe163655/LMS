using Contracts.Interfaces;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;

        private readonly Lazy<IAccountRepository> _accountRepository;

        private readonly Lazy<INewsRepository> _newsRepository;

        private readonly Lazy<INotificationRepository> _notificationsRepository;

        private readonly Lazy<IStudentDetailRepository> _studentDetailRepository;

        private readonly Lazy<IFileRepository> _fileRepository;

        private readonly Lazy<IFolderClosureRepository> _folderClosureRepository;

        private readonly Lazy<IFolderRepository> _folderRepository;

        private readonly Lazy<IScheduleRepository> _scheduleRepository;

        private readonly Lazy<ITaskRepository> _taskRepository;

        private readonly Lazy<IReportRepository> _reportRepository;

        private readonly Lazy<IDeviceRepository> _deviceRepository;

        private readonly Lazy<INewsFileRepository> _newsFileRepository;

        private readonly Lazy<ITaskHistoryRepository> _taskHistoryRepository;
        private readonly Lazy<ITaskListRepository> _taskListRepository;
        private readonly Lazy<IProjectRepository> _projectRepository;
        private readonly Lazy<IProjectTypeRepository> _projectTypeRepository;
        private readonly Lazy<IMemberRepository> _memberRepository;
        public RepositoryManager(DataContext context)
        {
            _context = context;

            _accountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(context));

            _newsRepository = new Lazy<INewsRepository>(() => new NewsRepository(context));

            _notificationsRepository = new Lazy<INotificationRepository>(() => new NotificationRepository(context));

            _studentDetailRepository = new Lazy<IStudentDetailRepository>(() => new StudentDetailRepository(context));

            _notificationsRepository = new Lazy<INotificationRepository>(() => new NotificationRepository(context));

            _fileRepository = new Lazy<IFileRepository>(() => new FileRepository(context));

            _folderRepository = new Lazy<IFolderRepository>(() => new FolderRepository(context));

            _folderClosureRepository = new Lazy<IFolderClosureRepository>(() => new FolderClosureRepository(context));

            _scheduleRepository = new Lazy<IScheduleRepository>(() => new ScheduleRepository(context));

            _taskRepository = new Lazy<ITaskRepository>(() => new TaskRepository(context));

            _taskHistoryRepository = new Lazy<ITaskHistoryRepository>(() => new TaskHistoryRepository(context));

            _taskListRepository = new Lazy<ITaskListRepository>(() => new TaskListRepository(context));

            _projectRepository = new Lazy<IProjectRepository>(() => new ProjectRepository(context));

            _memberRepository = new Lazy<IMemberRepository>(() => new MemberRepository(context));

            _projectTypeRepository = new Lazy<IProjectTypeRepository>(() => new ProjectTypeRepository(context));

            _reportRepository = new Lazy<IReportRepository>(() => new ReportRepository(context));

            _newsFileRepository = new Lazy<INewsFileRepository>(() => new NewsFileRespository(context));

            _deviceRepository = new Lazy<IDeviceRepository>(() => new DeviceRepository(context));
            //khoi tao newsRepo
        }
        public IAccountRepository Account => _accountRepository.Value;
        public INewsRepository News => _newsRepository.Value;
        public INotificationRepository Notification => _notificationsRepository.Value;
        public IStudentDetailRepository StudentDetail => _studentDetailRepository.Value;
        public IFileRepository File => _fileRepository.Value;
        public IFolderClosureRepository FolderClosure => _folderClosureRepository.Value;
        public IFolderRepository Folder => _folderRepository.Value;
        public IScheduleRepository Schedule => _scheduleRepository.Value;
        public ITaskRepository Task => _taskRepository.Value;
        public ITaskHistoryRepository TaskHistory => _taskHistoryRepository.Value;
        public IReportRepository Report => _reportRepository.Value;
        public ITaskListRepository TaskList => _taskListRepository.Value;
        public INewsFileRepository NewsFile => _newsFileRepository.Value;

        public IProjectRepository Project => _projectRepository.Value;

        public IMemberRepository Member => _memberRepository.Value;

        public IProjectTypeRepository ProjectType => _projectTypeRepository.Value;

        public IDeviceRepository Device => _deviceRepository.Value;

        public async Task Save() => await _context.SaveChangesAsync();
    }
}
