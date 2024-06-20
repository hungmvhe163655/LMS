using AutoMapper;
using Contracts.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class AccountService : IAccountService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<Account> _userManager;

        public AccountService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, UserManager<Account> userManager)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }
       // public async Task<Account> GetUserByEmail(string email) =>  _repository.account.GetByCondition(entity => entity.Email.Equals(email), false).FirstOrDefault();
        public async Task<Account> GetUserByEmail(string email)
        {
            var end = await _repository.account.GetByConditionAsync(entity => entity.Email.Equals(email), false);
            return end.First();
        }
        public async Task<Account> GetUserById(string id) => await _repository.account.GetByCondition(entity=>entity.Id.Equals(id), false).FirstAsync();
        public async Task<Account> GetUserByName(string userName)
        {
            try
            {
                var user = await _repository.account.FindByNameAsync(userName, false);
                return user;
            }catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateAccountVerifyStatus(IEnumerable<string> UserIDList,string verifier)
        {
            List<Account> accountList = new List<Account>();
            if(UserIDList.Any())
            {
                foreach(var ID in UserIDList)
                {
                    accountList.Add(_repository.account.GetByCondition(entity=>entity.Id.Equals(ID),false).First());
                }
                if(accountList.Any())
                {
                    foreach(var account in accountList)
                    {
                        account.isVerified = true;
                        account.VerifiedBy = verifier;
                        _repository.account.Update(account);
                        _repository.Save();
                    }
                    return true;
                }
            }
            return false;
        }
        public async Task<IEnumerable<Account>> GetVerifierAccounts(string email)
        {
            try
            {
                var user = await _repository.account.GetByConditionAsync(entity=>entity.Email.Equals(email), false);
                var end = user.First();
                return  _repository.account.GetByCondition(entity => entity.VerifiedBy.Equals(end.Id), false).ToList();
            }
            catch { throw; }
        }

        public async Task<IdentityResult> ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            try
            {
                var user = await _repository.account.GetByConditionAsync(entity => entity.Id.Equals(userId), false);
                var account = user.FirstOrDefault();
                if (account != null)
                {
                    var result = await _userManager.ChangePasswordAsync(account, oldPassword, newPassword);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exceptions Occur at service {nameof(ChangePasswordAsync)} with the message\" + ex.messeage");
            }
            return IdentityResult.Failed();
        }

        //public async Task<bool> ChangePhone(string userId, string newPhone, string verifyCode)
        //{
        //    if (VerifyPhoneCode(userId, verifyCode))
        //    {
        //        var user = await _repository.account.GetByConditionAsync(entity => entity.Id.Equals(userId), false);
        //        var account = user.FirstOrDefault();
        //        if (account != null)
        //        {
        //            account.PhoneNumber = newPhone;
        //            _repository.account.Update(account);
        //            await _repository.SaveAsync();
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public async Task<bool> ChangeEmail(string userId, string newEmail, string verifyCode)
        //{
        //    if (VerifyEmailCode(userId, verifyCode))
        //    {
        //        var user = await _repository.account.GetByConditionAsync(entity => entity.Id.Equals(userId), false);
        //        var account = user.FirstOrDefault();
        //        if (account != null)
        //        {
        //            account.Email = newEmail;
        //            _repository.account.Update(account);
        //            await _repository.SaveAsync();
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //private bool VerifyPhoneCode(string userId, string verifyCode)
        //{
        //    // Implement your phone code verification logic here
        //    return true; // Placeholder
        //}

        //private bool VerifyEmailCode(string userId, string verifyCode)
        //{
        //    // Implement your email code verification logic here
        //    return true; // Placeholder
        //}

        public async Task<IdentityResult> UpdateProfileAsync(string userId, string name, string rollNumber, string major, string specialized)
        {
            try
            {
                var user = await _repository.account.GetByConditionAsync(entity => entity.Id.Equals(userId), false);
                var account = user.FirstOrDefault();
                if (account != null)
                {
                    if(name != null)
                    {
                        account.FullName = name;
                    }
                    if(rollNumber != null)
                    {
                        account.StudentDetail.RollNumber = rollNumber;
                    }
                    if(major != null)
                    {
                        account.StudentDetail.Major = major;
                    }
                    if(specialized != null)
                    {
                        account.StudentDetail.Specialized = specialized;
                    }
                    await _repository.account.UpdateAsync(account);
                    return IdentityResult.Success;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exceptions Occur at service {nameof(ChangePasswordAsync)} with the message\" + ex.messeage");
            }
            return IdentityResult.Failed();
        }
    }
}
