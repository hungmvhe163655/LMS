using Contracts.Interfaces;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MailService : IMailService
    {
        private readonly ILoggerManager _logger;
        private readonly SmtpClient _smtpClient;
        private readonly UserManager<Account> _userManager;
        private readonly IMemoryCache _cache;
        private readonly IRepositoryManager _repository;
        public MailService(
            ILoggerManager logger,
            SmtpClient smtpClient,
            UserManager<Account> userManager,
            IMemoryCache memoryCache,
            IRepositoryManager repository)
        {
            _logger = logger;
            _smtpClient = smtpClient;
            _userManager = userManager;
            _cache = memoryCache;
            _repository = repository;
        }

        private string GenerateOtp()
        {
            Random random = new Random();
            int otp = random.Next(1000000, 1999999);
            return otp.ToString().Substring(1);
        }
        private string GetCacheKeyForTwoFactorToken(Account user)
        {
            return $"TwoFactorToken_{user.Id}";
        }
        private string GetCacheKeyForForgotPasswordToken(Account user)
        {
            return $"ForgotPasswordToken_{user.Id}";
        }
        //lmao
        public async Task<bool>VerifyTwoFactorOtp(string email,string token)
        {

            if (email == null) throw new ArgumentNullException(nameof(Account));
            if (string.IsNullOrWhiteSpace(token)) throw new ArgumentNullException(nameof(token));
            try
            {
                var hold_user = await _userManager.FindByEmailAsync(email);
                if (hold_user != null && hold_user.TwoFactorEnabled)
                {
                    var cacheKey = GetCacheKeyForTwoFactorToken(hold_user);
                    if (_cache.TryGetValue(cacheKey, out string storedToken))
                    {
                        return storedToken.Equals(token);
                    }                
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        public async Task<bool> SendTwoFactorOtp(string? email)
        {
            try
            {
                var hold_user = await _userManager.FindByEmailAsync(email);
                if (hold_user != null && hold_user.TwoFactorEnabled)
                {
                    var Token = await _userManager.GenerateTwoFactorTokenAsync(hold_user, "Email");
                    _cache.Set(GetCacheKeyForTwoFactorToken(hold_user),Token, TimeSpan.FromMinutes(2));
                    return await SendMailGmailSmtp(Environment.GetEnvironmentVariable("EMAILADMIN").Split("/")[0], hold_user.Email, "LMS - LOGIN VERIFY", "Your login Verify Code: " + Token);
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        public async Task<bool> VerifyForgotPasswordOtp(string email, string token)
        {

            if (email == null) throw new ArgumentNullException(nameof(Account));
            if (string.IsNullOrWhiteSpace(token)) throw new ArgumentNullException(nameof(token));
            try
            {
                var hold_user = await _userManager.FindByEmailAsync(email);
                if (hold_user != null)
                {
                    var cacheKey = GetCacheKeyForForgotPasswordToken(hold_user);
                    if (_cache.TryGetValue(cacheKey, out string storedToken))
                    {
                        return storedToken.Equals(token);
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        public async Task<bool> SendForgotPasswordOtp(string? email, string? phone)
        {
            try
            {
                if(email != null)
                {
                    var hold_user = await _userManager.FindByEmailAsync(email);
                    if (hold_user != null && hold_user.TwoFactorEnabled)
                    {
                        var Token = await _userManager.GenerateTwoFactorTokenAsync(hold_user, "Email");
                        _cache.Set(GetCacheKeyForForgotPasswordToken(hold_user), Token, TimeSpan.FromMinutes(2));
                        return await SendMailGmailSmtp(Environment.GetEnvironmentVariable("EMAILADMIN").Split("/")[0], hold_user.Email, "LMS - FORGOT PASSWORD VERIFY", "Your Verify Code: " + Token);
                    }
                }
                if(phone != null)// chua implement so dien thoai do khong co service nao ho tro nen dung tam email
                {
                    var hold_user = await _repository.account.GetByConditionAsync(entity => entity.PhoneNumber.Equals(phone) && entity.PhoneNumberConfirmed, false);
                    if (hold_user != null)
                    {
                        var end = hold_user.FirstOrDefault(entity=>entity.PhoneNumber.Equals(phone));
                        var Token = await _userManager.GenerateTwoFactorTokenAsync(end, "Email");
                        _cache.Set(GetCacheKeyForForgotPasswordToken(end), Token, TimeSpan.FromMinutes(2));
                        return await SendMailGmailSmtp(Environment.GetEnvironmentVariable("EMAILADMIN").Split("/")[0], end.Email, "LMS - FORGOT PASSWORD VERIFY", "Your Verify Code: " + Token);
                    }
                }
                
            }
            catch
            {
                return false;
            }
            return false;
        }
        public async Task<bool> SendVerifyOtp(string? email)
        {
            try
            {
                var hold_user = await _userManager.FindByEmailAsync(email);
                if (hold_user != null && !hold_user.EmailConfirmed)
                {
                    hold_user.EmailVerifyCode = GenerateOtp();
                    hold_user.EmailVerifyCodeAge = DateTime.Now.AddDays(1);
                    await _userManager.UpdateAsync(hold_user);
                    return await SendMailGmailSmtp(Environment.GetEnvironmentVariable("EMAILADMIN").Split("/")[0], hold_user.Email, "LMS - EMAIL VERIFY","Your Email Verify Code: "+ hold_user.EmailVerifyCode);
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        public async Task<bool> SendMailToUser(string? email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(user.EmailVerifyCode))
            {

            }
            return false;
        }
        private async Task<bool> SendMail(string _from, string _to, string _subject, string _body, SmtpClient client)
        {
            MailMessage message = new MailMessage(
                from: _from,
                to: _to,
                subject: _subject,
                body: _body
            );
            message.BodyEncoding = Encoding.UTF8;

            message.SubjectEncoding = Encoding.UTF8;

            message.IsBodyHtml = true;

            message.ReplyToList.Add(new MailAddress(_from));

            message.Sender = new MailAddress(_from);

            try
            {
                await client.SendMailAsync(message);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to send email at {nameof(SendMail)}");
                return false;
            }
        }
        private async Task<bool> SendMailGmailSmtp(string _from, string _to, string _subject, string _body)
        { 
                    return await SendMail(_from, _to, _subject, _body, _smtpClient);
        }
    }
}
