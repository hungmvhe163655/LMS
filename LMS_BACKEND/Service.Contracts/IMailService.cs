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
        Task<bool> VerifyTwoFactorOtp(string email,string token);
        Task<bool> SendTwoFactorOtp(string? email);
        Task<bool> SendMailToUser(string? email);
        Task<bool> SendVerifyOtp(string? email);
        Task<bool> SendForgotPasswordOtp(string? email, string? phone);
        Task<bool> VerifyForgotPasswordOtp(string Email, string token);
    }
}
