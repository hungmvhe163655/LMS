using Contracts.Interfaces;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        //add more here
        private readonly Lazy<IAccountService> _accountService;
        //
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger) 
        {
            _accountService = new Lazy<IAccountService>(() => new AccountService(repositoryManager, logger));
        }
        public IAccountService accountService => _accountService.Value;
    }
}
