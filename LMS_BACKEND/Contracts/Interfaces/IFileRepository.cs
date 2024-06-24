using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IFileRepository : IRepositoryBase<Files>
    {
        Files GetFile(Guid id, bool track);
        bool EditFile(Files hold);
        Task<bool> CreateFile(Files hold);
        Task<IEnumerable<Files>> GetFiles(bool track);
    }
}
