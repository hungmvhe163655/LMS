using Contracts.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FolderRepository : RepositoryBase<Folder>, IFolderRepository
    {
        public FolderRepository(DataContext context) : base(context)
        {
        }
        public Folder GetFolder(Guid id, bool track)
        {
            return FindAll(track).Where(x=>x.Id.Equals(id)).ToList().First();
        }
        public async Task<bool> AddFolder(Folder folder)
        {
            await CreateAsync(folder);
            return true;
        }
    }
}
