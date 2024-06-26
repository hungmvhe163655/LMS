﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IFolderClosureRepository : IRepositoryBase<FolderClosure>
    {
        IEnumerable<FolderClosure> FindAncestors(Guid Ancs_Id, bool track);
        Task<bool> AddLeaf(IEnumerable<FolderClosure> hold);
        IEnumerable<FolderClosure> GetFolderContent(Guid Id, bool track);
        IEnumerable<FolderClosure> GetBranch(Guid Id, bool track);
    }
}
