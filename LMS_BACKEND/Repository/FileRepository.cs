using Entities.Models;
using Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class FileRepository : RepositoryBase<Files>, IFileRepository
    {
        public FileRepository(DataContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Files>> GetFiles(bool track) => await FindAll(track).OrderBy(x => x.Name).ToListAsync();
        public Files GetFile(Guid id, bool track)
        {
            return FindAll(track).Where(x => x.Id.Equals(id)).ToList().First();
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
