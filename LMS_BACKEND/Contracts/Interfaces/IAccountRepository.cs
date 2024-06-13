using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> FindByNameAsync(string userName, bool Trackable);
        Task<bool> CheckPassWord(string userName, string password);
        Task<bool> ChangePasswordAsync(Account a, string newPassword);
        Task<bool> ChangeEmailAsync(Account a, string newEmail);
        Task<bool> ChangePhoneAsync(Account a, string newPhone);
        Task<bool> UpdateProfileAsync(Account a, bool gender, string fullName, string major, string specialized, string rollNumber);
    }
}
