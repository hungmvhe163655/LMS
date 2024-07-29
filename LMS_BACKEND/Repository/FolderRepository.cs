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
        public async Task<(IQueryable<Folder> Data, int CountLeft)> GetFolderWithDescendantDepth1Id(FolderRequestParameters param, Guid FatherId)
        {
            var hold =
                (await
                GetByCondition
                    (x => x.Id
                    .Equals(FatherId), false)
                    .Include(x => x.FolderClosureDescendant
                    .Where(y => y.Depth == 1))
                    .FirstOrDefaultAsync()
                    ?? throw new BadRequestException("Invalid folderID"))
                    .FolderClosureDescendant
                    .Select(z => z.DescendantID).ToList();

            var end = GetByCondition(x => hold.Contains(x.Id), false).SortContent(param.Sorting);

            var result = param.Take > 0
                ? end
                .Skip(param.Top ?? SCROLL_LIST.DEFAULT_TOP)
                .Take(param.Take ?? SCROLL_LIST.SMALL30)
                : end;

            return (result, result.Count() - (end.Count() + param.Top ?? 0));
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
