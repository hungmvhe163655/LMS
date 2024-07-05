using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IFolderRepository
    {
        public Folder GetFolder(Guid id, bool track);
        Task<bool> AddFolder(Folder folder);
        bool UpdateFolder(Folder folder);
    }
}
