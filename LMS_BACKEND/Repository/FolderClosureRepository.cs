﻿using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class FolderClosureRepository : RepositoryBase<FolderClosure>, IFolderClosureRepository
    {
        public FolderClosureRepository(DataContext context) : base(context)
        {
        }
        public async Task<IEnumerable<FolderClosure>> GetProjectFoldersByRoot(Guid rootId, bool track)
        {
            return await GetByCondition(x => x.AncestorID.Equals(rootId), false).ToListAsync();
        }
        public IQueryable<FolderClosure> FindAncestors(Guid Ancs_Id, bool track)
        {
            return GetByCondition(x => x.DescendantID.Equals(Ancs_Id), track);
        }
        public IEnumerable<FolderClosure> FindDescendants(Guid guid, bool track)
        {
            return FindAll(track).Where(x => x.AncestorID.Equals(guid)).ToList();
        }
        public async Task<bool> AddLeaf(IEnumerable<FolderClosure> hold)
        {
            await AddRange(hold);
            return true;
        }
        public IEnumerable<FolderClosure> GetFolderContent(Guid Id, bool track)
        {
            return FindAll(track).Where(x => x.AncestorID.Equals(Id) && x.Depth == 1).ToList();
        }
        public IEnumerable<FolderClosure> GetBranch(Guid Id, bool track)
        {
            return FindAll(track).Where(x => x.DescendantID.Equals(Id)).OrderByDescending(x => x.Depth).ToList();
        }
        public void DeleteListFolder(IEnumerable<FolderClosure> folderClosures)
        {
            if (!folderClosures.Any()) throw new BadRequestException("Folder branch List can not be null");

            DeleteRange(folderClosures);
        }
    }
}
