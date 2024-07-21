using Contracts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.DataTransferObjects.RequestParameters;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(DataContext context) : base(context)
        {
        }

        public async Task<Account?> FindByNameAsync(string userName, bool trackable)
        {
            return await GetByCondition(x => x.UserName != null && x.UserName.Equals(userName), false).FirstOrDefaultAsync();
        }

        public async Task<PagedList<Account>> FindWithVerifierId(NeedVerifyParameters param)
        {
            var end = await
                GetByCondition(x => !x.IsVerified && !x.IsBanned && !x.IsDeleted, false)
                .Search(param)
                .Skip((param.PageNumber - 1) * param.PageSize)
                .Take(param.PageSize)
                .ToListAsync();

            return new PagedList<Account>(end, end.Count, param.PageNumber, param.PageSize);
        }
        public async Task<PagedList<Account>> FindWithVerifierIdSuper(NeedVerifyParameters param, List<string> validGuid)
        {
            var end = await
                GetByCondition(x => !x.IsVerified && !x.IsBanned && !x.IsDeleted, false)
                .Search(param)
                .Skip((param.PageNumber - 1) * param.PageSize)
                .Take(param.PageSize)
                .ToListAsync();

            var hold = validGuid.Any() ? end.Where(x => validGuid.Contains(x.Id)) : end;

            return new PagedList<Account>(end, end.Count, param.PageNumber, param.PageSize);
        }
    }
}
