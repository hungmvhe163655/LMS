using AutoMapper;
using Contracts.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly Lazy<IAuthenticationService> _authenticationService;
        //
        public ServiceManager(
            IRepositoryManager repositoryManager,
            ILoggerManager logger, IMapper mapper,
            UserManager<Account> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration) 
        {
            _accountService = new Lazy<IAccountService>(() => new AccountService(repositoryManager, logger,mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper,userManager,configuration,roleManager));
        }
        public IAccountService accountService => _accountService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;


    }
}
