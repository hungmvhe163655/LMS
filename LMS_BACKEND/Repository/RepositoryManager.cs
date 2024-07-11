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

        private readonly Lazy<ITaskHistoryRepository> _taskHistoryRepository;
        private readonly Lazy<ITaskListRepository> _taskListRepository;
        private readonly Lazy<IProjectRepository> _projectRepository;
        private readonly Lazy<IProjectStatusRepository> _projectStatusRepository;
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

            _projectStatusRepository = new Lazy<IProjectStatusRepository>(() => new ProjectStatusRepository(context));

            _projectTypeRepository = new Lazy<IProjectTypeRepository>(() => new ProjectTypeRepository(context));
            //khoi tao newsRepo
        }
        public IAccountRepository account => _accountRepository.Value;
        public INewsRepository news => _newsRepository.Value;
        public INotificationRepository notification => _notificationsRepository.Value;
        public IStudentDetailRepository studentDetail => _studentDetailRepository.Value;
        public IFileRepository file => _fileRepository.Value;
        public IFolderClosureRepository folderClosure => _folderClosureRepository.Value;
        public IFolderRepository folder => _folderRepository.Value;
        public IScheduleRepository schedule => _scheduleRepository.Value;
        public ITaskRepository task => _taskRepository.Value;
        public ITaskHistoryRepository taskHistory => _taskHistoryRepository.Value;

        public ITaskListRepository taskList => _taskListRepository.Value;

        public IProjectRepository project => _projectRepository.Value;

        public IMemberRepository member => _memberRepository.Value;

        public IProjectStatusRepository projectStatus => _projectStatusRepository.Value;

        public IProjectTypeRepository projectType => _projectTypeRepository.Value;

        public async Task Save() => await _context.SaveChangesAsync();
    }
}
