using Contracts.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.DataTransferObjects.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .ToListAsync();

            return new PagedList<Account>(end, end.Count, param.PageNumber, param.PageSize);
        }
    }
}
