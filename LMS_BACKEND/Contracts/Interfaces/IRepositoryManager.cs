namespace Contracts.Interfaces
{
    public interface IRepositoryManager
    {
        IAccountRepository account { get; }
        INewsRepository news { get; }
        INotificationRepository notification { get; }
        void Save();
    }
}
