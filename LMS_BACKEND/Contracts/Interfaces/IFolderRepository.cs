using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IFolderRepository
    {
        public Task<Folder> GetFolder(Guid id, bool track);
        Task<bool> AddFolder(Folder folder);
        bool UpdateFolder(Folder folder);
        IQueryable<Folder> GetRootByProjectId(Guid projectId);
    }
}
