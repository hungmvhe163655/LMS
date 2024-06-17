using AutoMapper;
using Contracts.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using System.Net.Mail;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        //add more here
        private readonly Lazy<IAccountService> _accountService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IMailService> _mailService;
        private readonly Lazy<INewsService> _newsService;
        private readonly IMemoryCache _cache;

        //
        public ServiceManager(
            IRepositoryManager repositoryManager,
            ILoggerManager logger, IMapper mapper,
            UserManager<Account> userManager,
            RoleManager<IdentityRole> roleManager,
            SmtpClient client,
            IConfiguration configuration,
            IMemoryCache memoryCache)
        {
            _accountService = new Lazy<IAccountService>(() => new AccountService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration, roleManager));
            _mailService = new Lazy<IMailService>(() => new MailService(logger, client, userManager, memoryCache));
            _newsService = new Lazy<INewsService>(() => new NewsService(logger, repositoryManager, mapper));
 
        }
        public IAccountService AccountService => _accountService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IMailService MailService => _mailService.Value;
        public INewsService NewsService => _newsService.Value;


    }
}
