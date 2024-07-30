using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.DataTransferObjects.RequestParameters;
using Shared.GlobalVariables;

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
        public async Task<PagedList<Account>> FindWithVerifierIdSuper(NeedVerifyParameters param, List<string> validGuid, string userId)
        {
            var end = await
                GetByCondition(x => !x.IsVerified && !x.IsBanned && !x.IsDeleted, false)
                .Search(param)
                .ToListAsync();
            if (param.Role == null) return PagedList<Account>.ToPagedList(end.Where(x => x.VerifiedBy != null && x.VerifiedBy.Equals(userId)), param.PageNumber, param.PageSize);

            if (param.Role.Equals(ROLES.STUDENT)) return PagedList<Account>.ToPagedList(validGuid.Any() ? end.Where(x => validGuid.Contains(x.Id) && x.VerifiedBy != null && x.VerifiedBy.Equals(userId)) : throw new BadRequestException("Invalid student ID"), param.PageNumber, param.PageSize);

            if (param.Role.Equals(ROLES.SUPERVISOR)) return PagedList<Account>.ToPagedList(validGuid.Any() ? end.Where(x => validGuid.Contains(x.Id)) : throw new BadRequestException("Invalid supervisor ID"), param.PageNumber, param.PageSize);

            throw new BadRequestException("Bad role request");
        }
    }
}
