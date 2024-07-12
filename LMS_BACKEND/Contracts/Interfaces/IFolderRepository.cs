using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IFolderRepository
    {
        public Folder GetFolder(Guid id, bool track);
        Task<bool> AddFolder(Folder folder);
        bool UpdateFolder(Folder folder);
    }
}
