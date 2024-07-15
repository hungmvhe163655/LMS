using Contracts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class FolderRepository : RepositoryBase<Folder>, IFolderRepository
    {
        public FolderRepository(DataContext context) : base(context)
        {
        }
        public async Task<Folder> GetFolder(Guid id, bool track)
        {
            return await GetByCondition(x => x.Id.Equals(id), track).FirstOrDefaultAsync() ?? new Folder();
        }
        public async Task<bool> AddFolder(Folder folder)
        {
            await CreateAsync(folder);
            return true;
        }
        public bool UpdateFolder(Folder folder)
        {
            Update(folder);
            return true;
        }
        public IQueryable<Folder> GetRootByProjectId(Guid projectId)
        {
            return GetByCondition(x => x.IsRoot && x.ProjectId.Equals(projectId), false);
        }
    }
}
