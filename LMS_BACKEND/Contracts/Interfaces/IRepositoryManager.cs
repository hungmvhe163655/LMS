﻿namespace Contracts.Interfaces
{
    public interface IRepositoryManager
    {
        IAccountRepository account { get; }
        INewsRepository news { get; }
        INotificationRepository notification { get; }
        IFileRepository file { get; }
        IFolderRepository folder { get; }
        IFolderClosureRepository folderClosure { get; }
        Task Save();
    }
}
