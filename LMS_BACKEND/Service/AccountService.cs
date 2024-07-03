using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
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
        public async Task<AccountReturnModel> GetUserByEmail(string email)
        {
            var end = await _repository.account.GetByConditionAsync(entity => entity.Email.Equals(email) && entity.IsVerified, false);

            var hold = await _userManager.GetRolesAsync(end.First());

            var result = _mapper.Map<AccountReturnModel>(end.First());

            foreach (var role in hold) result.Roles.Add(role);
            
            return result;
        }
        public async Task<AccountReturnModel> GetUserById(string id) => _mapper.Map<AccountReturnModel>(await _repository.account.GetByCondition(entity => entity.Id.Equals(id) && entity.IsVerified, false).FirstAsync());
        public async Task<AccountReturnModel> GetUserByName(string userName)
        {

            var user = await _repository.account.FindByNameAsync(userName, false);

            if (user == null) throw new BadRequestException("No user with username: " + userName);

            return _mapper.Map<AccountReturnModel>(user);
        }
        public async Task<AccountDetailResponseModel> GetAccountDetail(string userId)
        {
            var account= await _repository.account.GetByCondition(entity => entity.Id.Equals(userId), false).FirstAsync();
            if(account == null) throw new BadRequestException($"{nameof(account)} is not valid");
            var studentDetail = await _repository.studentDetail.
                GetByCondition(entity => entity.AccountId != null && entity.AccountId.Equals(userId), false).FirstAsync();
            var roleName= await _userManager.GetRolesAsync(account);
            var hold =  new AccountDetailResponseModel
            {
                Id = account.Id,
                FullName = account.FullName,
                Role = roleName.First(),
                Email = account.Email,
                PhoneNumber = account.PhoneNumber != null ? account.PhoneNumber : "",
                RollNumber = studentDetail.RollNumber != null ? studentDetail.RollNumber : "",
                Major= studentDetail.Major != null ? studentDetail.Major : "",
                Specialized = studentDetail.Specialized != null ? studentDetail.Specialized : "",
            };
            return hold;
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
        public async Task<IEnumerable<AccountReturnModel>> GetVerifierAccounts(string email)
        {
            var user = await _repository.account.GetByConditionAsync(entity => entity.Email != null && entity.Email.Equals(email), false);
            var end = user.First();
            if (end == null) throw new UnauthorizedException("Invalid User");
            return _mapper.Map<IEnumerable<AccountReturnModel>>(_repository.account.GetByCondition(entity => entity.VerifiedBy != null && entity.VerifiedBy.Equals(end.Id), false).ToList());
        }

        public async Task<IEnumerable<AccountReturnModel>> GetUserByRole(string role) => _mapper.Map<IEnumerable<AccountReturnModel>>((await _userManager.GetUsersInRoleAsync(role)).Where(x => x.IsVerified));


        public async Task<bool> ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            var user = await _repository.account.GetByConditionAsync(entity => entity.Id.Equals(userId), true);
            var account = user.FirstOrDefault();
            if (account != null)
            {
                var result = await _userManager.ChangePasswordAsync(account, oldPassword, newPassword);
                return result.Succeeded;
            }
            else throw new BadRequestException("User with id: " + userId + " is not exist");
        }

        public async Task UpdateProfileAsync(string userId, UpdateProfileRequestModel model)
        {
            try
            {
                var user = await _repository.account.GetByConditionAsync(entity => entity.Id.Equals(userId), true);

                var account = user.FirstOrDefault();

                if (account == null) throw new BadRequestException("User with id: " + userId + " is not exist");

                account.FullName = model.FullName;

                var hold = await _repository.studentDetail.GetByConditionAsync(entity => entity.AccountId != null && entity.AccountId.Equals(userId), true);
                var studentDetail = hold.FirstOrDefault();

                if (studentDetail == null)
                {
                    var newStudentDetail = new StudentDetail() { AccountId = userId, RollNumber = account.UserName, Major = model.Major, Specialized = model.Specialized };
                    await _repository.studentDetail.CreateAsync(newStudentDetail);
                }
                else
                {
                    studentDetail.Major = model.Major;
                    studentDetail.Specialized = model.Specialized;
                    _repository.studentDetail.Update(studentDetail);
                }
                _repository.account.Update(account);
                await _repository.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exceptions Occur at service {nameof(UpdateProfileAsync)} with the message" + ex.Message);
            }
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
