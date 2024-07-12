namespace Service.Contracts
{
    public interface IMailService
    {
        Task<bool> SendOTP(string email, string keymode);
        Task<bool> VerifyOtp(string email, string token, string keymode);
        Task<bool> VerifyTwoFactorOtp(string email, string token);
        Task<bool> SendTwoFactorOtp(string email);
        Task<bool> SendMailToUser(string email, string content, string header);
        Task<bool> SendVerifyEmailOtp(string email);
        public bool VerifyEmailOtp(string email, string AuCode);
    }
}
