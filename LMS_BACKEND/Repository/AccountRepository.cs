using Contracts.Interfaces;
using Entities.Models;
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

        public Task<bool> CheckPassWord(string userName, string password)
        {
            throw new NotImplementedException();
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

        //public async Task<Account> FindProfileByIdAsync(string id)
        //{
        //    var hold = await GetByConditionAsync(false);
        //    if(hold != null)
        //    {

        //    }
        //    return null;
        //}


        public async Task<bool> ChangePasswordAsync(Account a, string newPassword)
        {
            if (a != null)
            {   
                a.PasswordHash = newPassword;
                Update(a);
                return true;
            }
            return false;
        }

        public async Task<bool> ChangeEmailAsync(Account a, string newEmail)
        {
            if (a != null)
            {
                a.Email = newEmail;
                Update(a);
                return true;
            }
            return false;
        }

        public async Task<bool> ChangePhoneAsync(Account a, string newPhone)
        {
            if (a != null)
            {
                a.PhoneNumber = newPhone;
                Update(a);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateProfileAsync(Account a, bool gender, string fullName, string major, string specialized, string rollNumber)
        {
            if (a != null)
            {
                if (gender) a.Gender = gender;
                if(fullName != null) a.FullName = fullName;
                if (major != null) a.StudentDetail.Major = major;
                if (specialized != null) a.StudentDetail.Specialized = specialized;
                if (rollNumber != null) a.StudentDetail.RollNumber = rollNumber;
                Update(a);
                return true;
            }
            return false;
        }
    }
}
