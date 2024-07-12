using Contracts.Interfaces;
using Entities.Models;

namespace Repository
{
    public class FolderRepository : RepositoryBase<Folder>, IFolderRepository
    {
        public FolderRepository(DataContext context) : base(context)
        {
        }
        public Folder GetFolder(Guid id, bool track)
        {
            return FindAll(track).Where(x => x.Id.Equals(id)).ToList().First();
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
    }
}
