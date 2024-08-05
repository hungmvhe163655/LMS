using Entities.Models;
using Shared.DataTransferObjects.RequestParameters;

namespace Contracts.Interfaces
{
    public interface IFolderRepository : IRepositoryBase<Folder>
    {
        Task<Folder> GetFolder(Guid id, bool track);
        Task<(IQueryable<Folder> Data, int Cursor)> GetFolderWithDescendantDepth1Id(FolderRequestParameters param, Guid FatherId);
        Task<bool> AddFolder(Folder folder);
        bool UpdateFolder(Folder folder);
        IQueryable<Folder> GetRootByProjectId(Guid projectId);
    }
}
