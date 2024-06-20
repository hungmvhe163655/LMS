using Amazon.S3;
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
        private readonly Lazy<IFileService> _fileService;

        //
        public ServiceManager(
            IRepositoryManager repositoryManager,
            ILoggerManager logger, IMapper mapper,
            UserManager<Account> userManager,
            RoleManager<IdentityRole> roleManager,
            SmtpClient client,
            IConfiguration configuration,
            IMemoryCache memoryCache,
            IAmazonS3 clients3
            )
        {
            _accountService = new Lazy<IAccountService>(() => new AccountService(repositoryManager, logger,mapper, userManager));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper,userManager,configuration,roleManager));
            _mailService = new Lazy<IMailService>(() => new MailService(logger,client,userManager,memoryCache,repositoryManager));
            _newsService = new Lazy<INewsService>(() => new NewsService(logger, repositoryManager, mapper));
            _fileService = new Lazy<IFileService>(() => new FileService(clients3, configuration));
        }
        public IAccountService AccountService => _accountService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IMailService MailService => _mailService.Value;
        public INewsService NewsService => _newsService.Value;
        public IFileService FileService => _fileService.Value;


    }
}
