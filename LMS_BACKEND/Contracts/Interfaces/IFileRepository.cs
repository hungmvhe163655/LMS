using Entities.Models;
using Shared.DataTransferObjects.RequestParameters;

namespace Contracts.Interfaces
{
    public interface IFileRepository : IRepositoryBase<Files>
    {
        IQueryable<Files> GetFile(Guid id, bool track);
        Task<(IQueryable<Files> Data, int Cursor)> GetFileWithFolderId(FilesRequestParameters param, Guid FolderId);
        bool EditFile(Files hold);
        Task<bool> CreateFile(Files hold);
        Task<IEnumerable<Files>> GetFiles(bool track, Guid FolderId);
    }
}
