using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        public async Task ChangeVerifierForId(string id, string verifierId)
        {
            var hold = await _repository.account.GetByCondition(x => x.Id.Equals(id), true).FirstOrDefaultAsync() ?? throw new BadRequestException("Invalid Account Id");

            var hold_verifier = _userManager.GetUsersInRoleAsync("Supervisor").Result.Where(x => x.Id.Equals(verifierId)).FirstOrDefault() ?? throw new BadRequestException("Invalid verifier Id");

            hold.VerifiedBy = hold_verifier.Id;

            await _repository.Save();
        }
        // public async Task<Account> GetUserByEmail(string email) =>  _repository.account.GetByCondition(entity => entity.Email.Equals(email), false).FirstOrDefault();
        public async Task<AccountReturnModel> GetUserByEmail(string email)
        {
            var end = await _repository.account.GetByConditionAsync(entity => entity.Email != null && entity.Email.Equals(email) && entity.IsVerified, false);

            if (end.IsNullOrEmpty()) return _mapper.Map<AccountReturnModel>(end.FirstOrDefault()); 

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
            var account = await _repository.account.GetByCondition(entity => entity.Id.Equals(userId), false).FirstAsync();
            if (account == null) throw new BadRequestException($"{nameof(account)} is not valid");
            if (account.Email == null) throw new BadRequestException($"{nameof(account.Email)} is not valid");

            var checkRole = await _userManager.GetRolesAsync(account);
            var roleName = checkRole.FirstOrDefault();
            if (roleName == null) throw new BadRequestException($"{roleName} is not valid");

            var hold = _mapper.Map<AccountDetailResponseModel>(account);
            hold.Role = roleName;

            if (roleName.ToUpper().Equals("STUDENT"))
            {
                var studentDetail = await _repository.studentDetail
                    .GetByConditionAsync(entity => entity.AccountId != null && entity.AccountId.Equals(userId), false);
                var detail = studentDetail.FirstOrDefault();

                if (detail != null)
                {
                    _mapper.Map(detail, hold);
                }
            }

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
        public async Task<IEnumerable<MinorAccountReturnModel>> GetAccountNameWithRole(string role) => _mapper.Map<IEnumerable<MinorAccountReturnModel>>((await _userManager.GetUsersInRoleAsync(role)).Where(x => x.IsVerified));
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

                var checkRole = await _userManager.GetRolesAsync(account);
                var roleName = checkRole.FirstOrDefault();
                if (roleName == null) throw new BadRequestException($"{roleName} is not valid");

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
                account.Gender = model.Gender.Equals("Male") ? true : false ;
                account.FullName = model.FullName;
                _repository.account.Update(account);
                await _repository.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exceptions Occur at service {nameof(UpdateProfileAsync)} with the message" + ex.Message);
            }
        }

        public async Task ChangeEmailAsync(string id, ChangeEmailRequestModel model)
        {
            var user = await _repository.account.GetByConditionAsync(entity => entity.Id.Equals(id), true);
            var account = user.FirstOrDefault();
            //if (account != null)
            //{
            //    var result = await _userManager.ChangeEmailAsync(account, oldPassword, newPassword);
            //    return result.Succeeded;
            //}
            //else throw new BadRequestException("User with id: " + userId + " is not exist");
            if (account == null) throw new BadRequestException($"Can't find user with id: ${id}");
            await _userManager.SetEmailAsync(account, model.Email);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(account);

            await _userManager.ConfirmEmailAsync(account, token);
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
