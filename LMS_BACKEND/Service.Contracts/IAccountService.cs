﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAccountService
    {
        Task<Account> GetUserByName(string userName);
        Task<Account> GetUserByEmail(string email);
        Task<Account> GetUserById(string id);
        Task<IEnumerable<Account>> GetVerifierAccounts(string userName);
        Task<bool> UpdateAccountVerifyStatus(IEnumerable<string> userIdList,string verifier);
    }
}
