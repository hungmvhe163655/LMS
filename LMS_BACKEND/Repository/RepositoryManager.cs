using Contracts.Interfaces;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;
        private readonly Lazy<IAccountRepository> _accountRepository;
        private readonly Lazy<INewsRepository> _newsRepository;
        private readonly Lazy<INotificationRepository> _notificationsRepository;
        private readonly Lazy<IFileRepository> _fileRepository;
        private readonly Lazy<IFolderClosureRepository> _folderClosureRepository;
        private readonly Lazy<IFolderRepository> _folderRepository;
        public RepositoryManager(DataContext context)
        {
            _context = context;
            _accountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(context));
            _newsRepository = new Lazy<INewsRepository>(() => new NewsRepository(context));
            _notificationsRepository = new Lazy<INotificationRepository>(() => new NotificationRepository(context));
            _fileRepository = new Lazy<IFileRepository>(() => new FileRepository(context));
            _folderRepository = new Lazy<IFolderRepository>(() => new FolderRepository(context));
            _folderClosureRepository = new Lazy<IFolderClosureRepository>(() => new FolderClosureRepository(context));
            //khoi tao newsRepo
        }
        public IAccountRepository account => _accountRepository.Value;
        public INewsRepository news => _newsRepository.Value;
        public INotificationRepository notification => _notificationsRepository.Value;
        public IFileRepository file => _fileRepository.Value;
        public IFolderClosureRepository folderClosure => _folderClosureRepository.Value;
        public IFolderRepository folder => _folderRepository.Value;
        public async Task Save() => await _context.SaveChangesAsync();
    }
}
