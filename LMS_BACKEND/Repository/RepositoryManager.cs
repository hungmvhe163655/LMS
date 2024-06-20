using Contracts.Interfaces;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;
        private readonly Lazy<IAccountRepository> _accountRepository;
        private readonly Lazy<INewsRepository> _newsRepository;
        public RepositoryManager(DataContext context)
        {
            _context = context;
            _accountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(context));
            //khoi tao newsRepo
        }
        public IAccountRepository account => _accountRepository.Value;

        public INewsRepository news => _newsRepository.Value;

        public void Save() => _context.SaveChanges();
    }
}
