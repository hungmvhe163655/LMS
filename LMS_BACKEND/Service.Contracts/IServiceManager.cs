namespace Service.Contracts
{
    public interface IServiceManager
    {
        IAccountService AccountService { get; }
        IAuthenticationService AuthenticationService { get; }
        IMailService MailService { get; }
        IFileService FileService { get; }
        INewsService NewsService { get; }
    }
}
