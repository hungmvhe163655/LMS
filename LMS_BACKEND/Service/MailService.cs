using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Service.Contracts;
using System.Net.Mail;
using System.Text;

namespace Service
{
    public class MailService : IMailService
    {
        private readonly ILoggerManager _logger;
        private readonly SmtpClient _smtpClient;
        private readonly UserManager<Account> _userManager;
        private readonly IMemoryCache _cache;
        private readonly IRepositoryManager _repository;
        private readonly string _Mail;
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
            var hold = Environment.GetEnvironmentVariable("EMAILADMIN");
            _Mail = hold ?? "//////";
        }

        private static string GenerateOtp()
        {
            Random random = new Random();
            int otp = random.Next(1000000, 1999999);
            return otp.ToString().Substring(1);
        }
        private string GetCacheKey(Account user, string keymode)
        {
            return $"{keymode}_{user.Id}";
        }
        private string GetVerifyEmailKey(string email)
        {
            return $"{email}_verifyEmail";
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public async Task<bool> SendOTP(string email, string keymode)
        {
            try
            {
                if (email != null)
                {
                    var hold_user = await _userManager.FindByEmailAsync(email);
                    if (hold_user != null && hold_user.Email != null)
                    {
                        var Token = GenerateOtp();
                        _cache.Set(GetCacheKey(hold_user, keymode), Token, TimeSpan.FromMinutes(2));
                        return await SendMailGmailSmtp(_Mail.Split("/")[0], hold_user.Email, "LMS - EMAIL VERIFY", "Your Verify Code: " + Token);
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        public async Task<bool> VerifyOtp(string email, string token, string keymode)
        {

            if (email == null || !IsValidEmail(email)) throw new BadRequestException("Email is not valid");

            if (string.IsNullOrWhiteSpace(token)) throw new ArgumentNullException(nameof(token));
            try
            {
                var hold_user = await _userManager.FindByEmailAsync(email);
                if (hold_user != null)
                {
                    var cacheKey = GetCacheKey(hold_user, keymode);
                    if (_cache.TryGetValue(cacheKey, out string? storedToken))
                    {
                        return !string.IsNullOrEmpty(storedToken) ? storedToken.Equals(token) : false;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        //lmao
        public async Task<bool> VerifyTwoFactorOtp(string email, string token)
        {

            if (email == null || !IsValidEmail(email)) throw new BadRequestException("Email is not valid");

            if (string.IsNullOrWhiteSpace(token)) throw new ArgumentNullException(nameof(token));
            try
            {
                var hold_user = await _userManager.FindByEmailAsync(email);
                if (hold_user != null && hold_user.TwoFactorEnabled)
                {
                    var cacheKey = GetCacheKey(hold_user, "TwoFactorToken");
                    if (_cache.TryGetValue(cacheKey, out string? storedToken))
                    {
                        return !string.IsNullOrEmpty(storedToken) ? storedToken.Equals(token) : false;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        public async Task<bool> SendTwoFactorOtp(string email)
        {
            try
            {
                var hold_user = await _userManager.FindByEmailAsync(email);
                if (hold_user != null && hold_user.Email != null && hold_user.TwoFactorEnabled)
                {
                    var Token = await _userManager.GenerateTwoFactorTokenAsync(hold_user, "Email");
                    _cache.Set(GetCacheKey(hold_user, "TwoFactorToken"), Token, TimeSpan.FromMinutes(2));
                    return await SendMailGmailSmtp(_Mail.Split("/")[0], hold_user.Email, "LMS - LOGIN VERIFY", "Your login Verify Code: " + Token);
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        public async Task<bool> SendVerifyEmailOtp(string email)
        {
            if (email == null || !IsValidEmail(email)) throw new BadRequestException("Email is not valid");

            var hold_user = await _userManager.FindByEmailAsync(email);

            if (hold_user != null) throw new BadRequestException("Email is already existed");

            var token = GenerateOtp();

            _cache.Set(GetVerifyEmailKey(email), token, TimeSpan.FromMinutes(2));

            return await SendMailGmailSmtp(_Mail.Split("/")[0], email, "LMS - EMAIL VERIFY", "Your email verification code: " + token + "\nThis code will be valid for 2 minutes");
        }
        public bool VerifyEmailOtp(string email, string AuCode)
        {
            if (email == null || !IsValidEmail(email)) throw new ArgumentNullException(nameof(Account));

            if (string.IsNullOrWhiteSpace(AuCode)) throw new ArgumentNullException(nameof(AuCode));

            var cacheKey = GetVerifyEmailKey(email);

            if (_cache.TryGetValue(cacheKey, out string? storedToken))
            {
                return !string.IsNullOrEmpty(storedToken) ? storedToken.Equals(AuCode) : false;
            }
            return false;
        }
        public async Task<bool> SendMailToUser(string email, string content, string header)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) throw new BadRequestException("Email is not valid");

            return await SendMailGmailSmtp(_Mail.Split("/")[0], email, header, content);
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
                _logger.LogWarning($"Failed to send email at {nameof(SendMail)}");
                _logger.LogWarning(ex.Message);
                return false;
            }
        }
        private async Task<bool> SendMailGmailSmtp(string _from, string _to, string _subject, string _body)
        {
            return await SendMail(_from, _to, _subject, _body, _smtpClient);
        }
    }
}
