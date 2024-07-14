using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IFileRepository : IRepositoryBase<Files>
    {
        IQueryable<Files> GetFile(Guid id, bool track);
        bool EditFile(Files hold);
        Task<bool> CreateFile(Files hold);
        Task<IEnumerable<Files>> GetFiles(bool track, Guid FolderId);
    }
}
