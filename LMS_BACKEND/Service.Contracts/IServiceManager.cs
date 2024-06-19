using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IAccountService AccountService { get; }
        IAuthenticationService AuthenticationService { get; }
        IMailService MailService { get; }
        IFileService FileService { get; }
    }
}
