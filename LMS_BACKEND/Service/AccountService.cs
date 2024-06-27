using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
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
    public sealed class AccountService : IAccountService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<Account> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountService
            (IRepositoryManager repository,
            ILoggerManager logger,
            IMapper mapper,
            UserManager<Account> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        // public async Task<Account> GetUserByEmail(string email) =>  _repository.account.GetByCondition(entity => entity.Email.Equals(email), false).FirstOrDefault();
        public async Task<IEnumerable<Account>> GetUserByEmail(string email)
        {
            var end = await _repository.account.GetByConditionAsync(entity => entity.Email.Equals(email), false);
            return end;
        }
        public async Task<Account> GetUserById(string id) => await _repository.account.GetByCondition(entity => entity.Id.Equals(id), false).FirstAsync();
        public async Task<Account> GetUserByName(string userName)
        {
            try
            {
                var user = await _repository.account.FindByNameAsync(userName, false);
                return user;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateAccountVerifyStatus(IEnumerable<string> UserIDList, string verifier)
        {
            List<Account> accountList = new List<Account>();
            if (UserIDList.Any())
            {
                foreach (var ID in UserIDList)
                {
                    accountList.Add(_repository.account.GetByCondition(entity => entity.Id.Equals(ID), false).First());
                }
                if (accountList.Any())
                {
                    foreach (var account in accountList)
                    {
                        account.IsVerified = true;
                        account.VerifiedBy = verifier;
                        _repository.account.Update(account);
                        await _repository.Save();
                    }
                    return true;
                }
            }
            return false;
        }
        public async Task<IEnumerable<Account>> GetVerifierAccounts(string email)
        {
                var user = await _repository.account.GetByConditionAsync(entity => entity.Email.Equals(email), false);
                var end = user.First();
                if (end == null) throw new UnauthorizedException("Invalid User");
                return _repository.account.GetByCondition(entity => entity.VerifiedBy.Equals(end.Id), false).ToList();
        }

        public async Task<IEnumerable<Account>> GetUserByRole(string role)
        {
            try
            {
                var hold = await _roleManager.FindByNameAsync(role);
                if (hold != null) return await _userManager.GetUsersInRoleAsync(hold.Name);
            }
            catch
            {
                throw;
            }
            return null;
        }

        public async Task<bool> ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            try
            {
                var user = await _repository.account.GetByConditionAsync(entity => entity.Id.Equals(userId), true);
                var account = user.FirstOrDefault();
                if (account != null)
                {
                    var result = await _userManager.ChangePasswordAsync(account, oldPassword, newPassword);
                    return result.Succeeded;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exceptions Occur at service {nameof(ChangePasswordAsync)} with the message\" + {ex.Message}");
            }
            return false;
        }

        public async Task<bool> UpdateProfileAsync(string userId, string name, string rollNumber, string major, string specialized)
        {
            try
            {
                var user = await _repository.account.GetByConditionAsync(entity => entity.Id.Equals(userId), true);

                var account = user.FirstOrDefault();

                if (account == null) return false;

                account.FullName = name;

                var listStudentDetail = await _repository.studentDetail.GetByConditionAsync(entity => entity.AccountId.Equals(userId), true);
                var studentDetail = listStudentDetail.FirstOrDefault();

                if (studentDetail == null)
                {
                    var newStudentDetail = new StudentDetail() { AccountId = userId, RollNumber = rollNumber, Major = major, Specialized = specialized };
                    await _repository.studentDetail.CreateAsync(newStudentDetail);
                }
                else
                {
                    studentDetail.RollNumber = rollNumber;
                    studentDetail.Major = major;
                    studentDetail.Specialized = specialized;
                    _repository.studentDetail.Update(studentDetail);
                }
                _repository.account.Update(account);
                await _repository.Save();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exceptions Occur at service {nameof(ChangePasswordAsync)} with the message\" + ex.messeage");
            }
            return false;
        }

        //public async Task<bool> ChangePhoneNumberAsync(string userId, string phoneNumber, string verifyCode)
        //{
        //    try
        //    {
        //        var user = await _repository.account.GetByConditionAsync(entity => entity.Id.Equals(userId), true);

        //        var account = user.FirstOrDefault();

        //        if (account != null)
        //        {
        //            if (account.StudentDetail == null)
        //            {
        //                account.StudentDetail = new StudentDetail() { AccountId = userId };
        //            }

        //            if (name != null)
        //            {
        //                account.FullName = name;
        //            }

        //            if (rollNumber != null)
        //            {
        //                account.StudentDetail.RollNumber = rollNumber;
        //            }
        //            if (major != null)
        //            {
        //                account.StudentDetail.Major = major;
        //            }
        //            if (specialized != null)
        //            {
        //                account.StudentDetail.Specialized = specialized;
        //            }

        //            await _repository.account.UpdateAsync(account);
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Exceptions Occur at service {nameof(ChangePasswordAsync)} with the message\" + ex.messeage");
        //    }
        //    return false;
        //}
    }

}
