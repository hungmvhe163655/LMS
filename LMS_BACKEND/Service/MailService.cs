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
        public MailService(ILoggerManager logger, SmtpClient smtpClient, UserManager<Account> userManager, IMemoryCache memoryCache)
        {
            _logger = logger;
            _smtpClient = smtpClient;
            _userManager = userManager;
            _cache = memoryCache;
        }

        private string GenerateOtp()
        {
            Random random = new Random();
            int otp = random.Next(1000000, 1999999);
            return otp.ToString().Substring(1);
        }
        private string GetCacheKeyForToken(Account user)
        {
            return $"TwoFactorToken_{user.Id}";
        }
        public async Task<bool>VerifyTwoFactorOtp(string username,string token)
        {

            if (username == null) throw new ArgumentNullException(nameof(Account));
            if (string.IsNullOrWhiteSpace(token)) throw new ArgumentNullException(nameof(token));
            try
            {
                var hold_user = await _userManager.FindByNameAsync(username);
                if (hold_user != null && hold_user.TwoFactorEnabled)
                {
                    var cacheKey = GetCacheKeyForToken(hold_user);
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
        public async Task<bool> SendTwoFactorOtp(string username, string? email)
        {
            try
            {
                var hold_user = await _userManager.FindByNameAsync(username);
                if (hold_user != null && hold_user.TwoFactorEnabled)
                {
                    var Token = await _userManager.GenerateTwoFactorTokenAsync(hold_user, "Email");
                    _cache.Set(GetCacheKeyForToken(hold_user),Token, TimeSpan.FromMinutes(2));
                    return await SendMailGmailSmtp(Environment.GetEnvironmentVariable("EMAILADMIN").Split("/")[0], hold_user.Email, "LMS - LOGIN VERIFY", "Your login Verify Code: " + Token);
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        public async Task<bool> SendVerifyOtp(string username,string? email)
        {
            try
            {
                var hold_user = await _userManager.FindByNameAsync(username);
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
        public async Task<bool> SendMailToUser(string username,string? email)
        {
            var user = await _userManager.FindByNameAsync(username);
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
