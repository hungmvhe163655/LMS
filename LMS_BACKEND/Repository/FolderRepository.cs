using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.DataTransferObjects.RequestParameters;
using Shared.GlobalVariables;

namespace Repository
{
    public class FolderRepository : RepositoryBase<Folder>, IFolderRepository
    {
        public FolderRepository(DataContext context) : base(context)
        {
        }
        public async Task<(IQueryable<Folder> Data, int? Cursor)> GetFolderWithDescendantDepth1Id(FolderRequestParameters param, Guid FatherId)
        {
            var hold =
                (await
                GetByCondition
                    (x => x.Id
                    .Equals(FatherId), false)
                    .Include(x => x.FolderClosureAncestor)
                    .FirstOrDefaultAsync()
                    ?? throw new BadRequestException("Invalid folderID"))
                    .FolderClosureAncestor
                    .Where(x => x.Depth == 1)
                    .Select(z => z.DescendantID).ToList();

            var end = GetByCondition(x => hold.Contains(x.Id), false).SortContent(param.OrderBy);

            if (param.Cursor == null) return (end, 0);

            var result = end
                .Skip(param.Cursor ?? SCROLL_LIST.DEFAULT_TOP)
                .Take(param.Take ?? SCROLL_LIST.TINY10);

            return (result, end.Count() > (result.Count() + param.Cursor ?? 0) ? (result.Count() + param.Cursor ?? 0) : null);
        }

        public async Task<IQueryable<Folder>> GetFolderWithDescendantDepth1Id_NoPaged(string? orderBy, Guid fatherId)
        {
            var hold =
                (await
                GetByCondition
                    (x => x.Id
                    .Equals(fatherId), false)
                    .Include(x => x.FolderClosureAncestor)
                    .FirstOrDefaultAsync()
                    ?? throw new BadRequestException("Invalid folderID"))
                    .FolderClosureAncestor
                    .Where(x => x.Depth == 1)
                    .Select(z => z.DescendantID).ToList();

            return GetByCondition(x => hold.Contains(x.Id), false).SortContent(orderBy);
        }

        public async Task<Folder> GetFolder(Guid id, bool track)
        {
            return await GetByCondition(x => x.Id.Equals(id), track).FirstOrDefaultAsync() ?? throw new BadRequestException("Invalid folder id");
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
