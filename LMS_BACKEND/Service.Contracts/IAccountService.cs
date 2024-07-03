using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
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
        Task UpdateProfileAsync(string userId, UpdateProfileRequestModel model);
        Task<AccountDetailResponseModel> GetAccountDetail(string userId);
    }
}
