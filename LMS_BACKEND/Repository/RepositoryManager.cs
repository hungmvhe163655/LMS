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
        public RepositoryManager(DataContext context)
        {
            _context = context;
            _accountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(context));
            _newsRepository = new Lazy<INewsRepository>(() => new NewsRepository(context));
            _notificationsRepository = new Lazy<INotificationRepository>(()=> new NotificationRepository(context));
            _studentDetailRepository = new Lazy<IStudentDetailRepository>(() => new StudentDetailRepository(context));
            //khoi tao newsRepo
        }
        public IAccountRepository account => _accountRepository.Value;

        public INewsRepository news => _newsRepository.Value;

        public INotificationRepository notification => _notificationsRepository.Value;

        public IStudentDetailRepository studentDetail => _studentDetailRepository.Value;

        public void Save() => _context.SaveChanges();
    }
}
