using Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;
        private readonly Lazy<IAccountRepository> _accountRepository;
        public RepositoryManager(DataContext context) 
        {
            _context = context;
            _accountRepository = new Lazy<IAccountRepository>(()=>new AccountRepository(context));
        }
        public IAccountRepository account  => _accountRepository.Value;

        public void Save() => _context.SaveChanges();
    }
}
