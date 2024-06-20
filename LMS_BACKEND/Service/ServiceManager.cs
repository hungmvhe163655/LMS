using Amazon.S3;
using AutoMapper;
using Contracts.Interfaces;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        //add more here
        private readonly Lazy<IAccountService> _accountService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IMailService> _mailService;
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
            IAmazonS3 s3) 
        {
            _accountService = new Lazy<IAccountService>(() => new AccountService(repositoryManager, logger,mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper,userManager,configuration,roleManager));
            _mailService = new Lazy<IMailService>(() => new MailService(logger,client,userManager,memoryCache,repositoryManager));
            _fileService = new Lazy<IFileService>(() => new FileService( s3, configuration));
        }
        public IAccountService AccountService => _accountService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IMailService MailService => _mailService.Value;

        public IFileService FileService => _fileService.Value;


    }
}
