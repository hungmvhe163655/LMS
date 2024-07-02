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
        Task<IEnumerable<AccountReturnModel>> GetUserByRole(string role);
        Task<AccountReturnModel> GetUserByName(string userName);
        Task<AccountReturnModel> GetUserByEmail(string email);
        Task<AccountReturnModel> GetUserById(string id);
        Task<IEnumerable<AccountReturnModel>> GetVerifierAccounts(string userName);
        Task<bool> UpdateAccountVerifyStatus(IEnumerable<string> userIdList,string verifier);
        Task<bool> ChangePasswordAsync(string userId, string oldPassword, string newPassword);
        Task UpdateProfileAsync(string userId, UpdateProfileRequestModel model);
    }
}
