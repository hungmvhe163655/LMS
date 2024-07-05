using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMailService
    {
        Task<bool> SendOTP(string email, string keymode);
        Task<bool> VerifyOtp(string email, string token, string keymode);
        Task<bool> VerifyTwoFactorOtp(string email,string token);
        Task<bool> SendTwoFactorOtp(string email);
        Task<bool> SendMailToUser(string email);
        Task<bool> SendVerifyOtp(string email);
    }
}
