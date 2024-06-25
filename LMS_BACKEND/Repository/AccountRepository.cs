using Contracts.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Account> FindByNameAsync(string userName, bool trackable)
        {
            var hold = await FindAllAsync(false);
            if (hold != null)
            {
                var end = hold.Where(x => x.UserName.Equals(userName)).First();
                return end != null ? end : null;
            }
            return null;
        }

        public Task<IQueryable<Account>> FindByVerifierAsync(string userName, bool Trackable)
        {
            throw new NotImplementedException();
        }
    }
}
