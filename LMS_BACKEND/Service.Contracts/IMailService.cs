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
        Task<bool> VerifyTwoFactorOtp(string username, string token);
        Task<bool> SendTwoFactorOtp(string username, string? email);
        Task<bool> SendMailToUser(string username, string? email);
        Task<bool> SendVerifyOtp(string username, string? email);
        Task<bool> SendForgotPasswordOtp(string? email, string? phone);
        Task<bool> VerifyForgotPasswordOtp(string Email, string token);
    }
}
