using Entities.Models;
using Shared.DataTransferObjects.RequestParameters;

namespace Contracts.Interfaces
{
    public interface IFolderRepository : IRepositoryBase<Folder>
    {
        Task<Folder> GetFolder(Guid id, bool track);
        Task<(IQueryable<Folder> Data, int? Cursor)> GetFolderWithDescendantDepth1Id(FolderRequestParameters param, Guid FatherId);

        Task<IQueryable<Folder>> GetFolderWithDescendantDepth1Id_NoPaged(string? orderBy, Guid fatherId);
        Task<bool> AddFolder(Folder folder);
        bool UpdateFolder(Folder folder);
        IQueryable<Folder> GetRootByProjectId(Guid projectId);
        IQueryable<Folder> GetFoldersByProjectId(Guid projectId, bool track);
    }
}
