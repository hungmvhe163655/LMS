using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetUserByRole(string role);
        Task<Account> GetUserByName(string userName);
        Task<IEnumerable<Account>> GetUserByEmail(string email);
        Task<Account> GetUserById(string id);
        Task<IEnumerable<Account>> GetVerifierAccounts(string userName);
        Task<bool> UpdateAccountVerifyStatus(IEnumerable<string> userIdList,string verifier);
        Task<bool> ChangePasswordAsync(string userId, string oldPassword, string newPassword);
        Task<bool> UpdateProfileAsync(string userId, string name, string rollNumber, string major, string specialized);
    }
}
