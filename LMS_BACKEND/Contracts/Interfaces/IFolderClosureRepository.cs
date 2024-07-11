using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IFolderClosureRepository : IRepositoryBase<FolderClosure>
    {
        IEnumerable<FolderClosure> FindAncestors(Guid Ancs_Id, bool track);
        Task<bool> AddLeaf(IEnumerable<FolderClosure> hold);
        IEnumerable<FolderClosure> GetFolderContent(Guid Id, bool track);
        IEnumerable<FolderClosure> GetBranch(Guid Id, bool track);
        void DeleteListFolder(IEnumerable<FolderClosure> folderClosures);
        IEnumerable<FolderClosure> FindDescendants(Guid guid, bool track);
    }
}
