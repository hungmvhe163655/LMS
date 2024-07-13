using Contracts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects.RequestParameters;

namespace Repository
{
    public class FileRepository : RepositoryBase<Files>, IFileRepository
    {
        public FileRepository(DataContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Files>> GetFiles(bool track, Guid FolderId) =>
            await
            GetByCondition(x => x.FolderId.Equals(FolderId), track)
            .OrderBy(x => x.Name)
            .ToListAsync();
        public async Task<IEnumerable<Files>> GetFilesWithQuery(bool track, FileRequestParameters parameters)
        {
            if (parameters.SearchTerm != null)
            {
                var query = FindAll(false).Where(x => x.Name.ToLower().Contains(parameters.SearchTerm.ToLower())).OrderBy(y => y.Name);
                return PagedList<Files>.ToPagedList(await query.ToListAsync(), parameters.PageNumber, parameters.PageSize);
            }
            else
            {
                var query = FindAll(false).OrderBy(y => y.Name);
                return PagedList<Files>.ToPagedList(await query.ToListAsync(), parameters.PageNumber, parameters.PageSize);
            }

        }
        public IQueryable<Files> GetFile(Guid id, bool track)
        {
            return FindAll(track).Where(x => x.Id.Equals(id));
        }
        public async Task<bool> CreateFile(Files hold)
        {
            await CreateAsync(hold);
            return true;
        }
        public bool EditFile(Files hold)
        {
            Update(hold);
            return true;
        }
    }
}
