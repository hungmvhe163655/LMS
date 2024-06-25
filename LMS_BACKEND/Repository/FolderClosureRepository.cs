using Contracts.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FolderClosureRepository : RepositoryBase<FolderClosure>, IFolderClosureRepository
    {
        public FolderClosureRepository(DataContext context) : base(context)
        {
        }
        public IEnumerable<FolderClosure> FindAncestors(string Ancs_Id, bool track)
        {
            return FindAll(track).Where(x => x.DescendantID.Equals(Ancs_Id)).ToList();
        }
        public async Task<bool> AddLeaf(IEnumerable<FolderClosure> hold)
        {
            foreach (var item in hold)
            {
                await CreateAsync(item);
            }
            return true;
        }
        public IEnumerable<FolderClosure> GetFolderContent(string Id, bool track)
        {
            return FindAll(track).Where(x=>x.AncestorID.Equals(Id)&&x.Depth==1).ToList();
        }
        public IEnumerable<FolderClosure> GetBranch(string Id, bool track)
        {
            return FindAll(track).Where(x=>x.DescendantID.Equals(Id)).OrderByDescending(x=>x.Depth).ToList();
        }
    }
}
