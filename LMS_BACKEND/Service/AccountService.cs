using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using Shared.GlobalVariables;
using System.Security.Claims;

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
        public async Task<string> CheckUser(ClaimsPrincipal user)
        {
            var userClaims = user.Claims;

            var username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? throw new BadRequestException("Please login first");

            var hold = await _repository.Account.FindByNameAsync(username, false) ?? throw new BadRequestException("Bad username");

            return hold.Id;
        }

        public async Task<IEnumerable<AccountManagementResponseModel>> TaskGetAccountForManagement(RequestParameters lamao)
        {
            var hold = await _repository.Account.GetPagedAsync(lamao, false);

            var end = _mapper.Map<IEnumerable<AccountManagementResponseModel>>(hold);

            foreach (var account in hold)
            {
                var roles = await _userManager.GetRolesAsync(account);

                var responseModel = end.First(e => e.Id == account.Id);

                responseModel.Role = roles;
            }

            return end;
        }

        public async Task DisableAccount(string id, bool flag)
        {
            var hold = await
                _repository
                .Account
                .GetByCondition(x => x.Id
                .Equals(id), true)
                .FirstOrDefaultAsync()
                ?? throw new BadRequestException("User with such ID does not existed");

            hold.IsBanned = flag;

            await _repository.Save();
        }
        public async Task ChangeVerifierForId(string id, string verifierId)
        {
            var hold = await _repository.Account.GetByCondition(x => x.Id.Equals(id), true).FirstOrDefaultAsync() ?? throw new BadRequestException("Invalid Account Id");

            var hold_verifier = _userManager.GetUsersInRoleAsync("Supervisor").Result.Where(x => x.Id.Equals(verifierId)).FirstOrDefault() ?? throw new BadRequestException("Invalid verifier Id");

            hold.VerifiedBy = hold_verifier.Id;

            await _repository.Save();
        }
        // public async Task<Account> GetUserByEmail(string email) =>  _repository.account.GetByCondition(entity => entity.Email.Equals(email), false).FirstOrDefault();
        public async Task<AccountReturnModel> GetUserByEmail(string email, bool Verified)
        {
            var end = Verified ? await _repository.Account.GetByConditionAsync(entity => entity.Email != null && entity.Email.Equals(email) && entity.IsVerified, false)
                               : await _repository.Account.GetByConditionAsync(entity => entity.Email != null && entity.Email.Equals(email), false);

            if (end.IsNullOrEmpty()) return _mapper.Map<AccountReturnModel>(end.FirstOrDefault());

            var hold = await _userManager.GetRolesAsync(end.First());

            var result = _mapper.Map<AccountReturnModel>(end.First());

            foreach (var role in hold) result.Roles.Add(role);

            return result;
        }
        public async Task<AccountReturnModel> GetUserById(string id) => _mapper.Map<AccountReturnModel>(await _repository.Account.GetByCondition(entity => entity.Id.Equals(id) && entity.IsVerified, false).FirstOrDefaultAsync());
        public async Task<AccountReturnModel> GetUserByName(string userName)
        {

            var user = await _repository.Account.FindByNameAsync(userName, false);

            if (user == null) throw new BadRequestException("No user with username: " + userName);

            return _mapper.Map<AccountReturnModel>(user);
        }
        public async Task<AccountDetailResponseModel> GetAccountDetail(string userId)
        {
            var account = await _repository.Account.GetByCondition(entity => entity.Id.Equals(userId), false).FirstAsync();

            if (account == null) throw new BadRequestException($"{nameof(account)} is not valid");

            if (account.Email == null) throw new BadRequestException($"{nameof(account.Email)} is not valid");

            var checkRole = await _userManager.GetRolesAsync(account);

            var roleName = checkRole.FirstOrDefault();

            if (roleName == null) throw new BadRequestException($"{roleName} is not valid");

            var hold = _mapper.Map<AccountDetailResponseModel>(account);

            hold.Role = roleName;

            if (roleName.ToUpper().Equals("STUDENT"))
            {
                var studentDetail = await
                    _repository
                    .StudentDetail
                    .GetByConditionAsync(entity => entity.AccountId != null && entity.AccountId.Equals(userId), false);
                var detail = studentDetail.FirstOrDefault();

                if (detail != null)
                {
                    _mapper.Map(detail, hold);
                }
            }

            return hold;
        }

        public async Task UpdateAccountVerifyStatus(IEnumerable<UserAcceptanceRequestModel> UserList, string verifier)
        {
            List<Account> accountListAccept = new List<Account>();

            List<Account> accountListReject = new List<Account>();

            List<string> UserIDListAccept = UserList.Where(x => x.IsApproved).Select(x => x.UserId).ToList();

            List<string> UserIDListReject = UserList.Where(x => !x.IsApproved).Select(y => y.UserId).ToList();

            accountListAccept.AddRange(await _repository.Account.GetByCondition(entity => UserIDListAccept.Contains(entity.Id) && !entity.IsVerified, false).ToListAsync());

            accountListReject.AddRange(await _repository.Account.GetByCondition(entity => UserIDListReject.Contains(entity.Id) && !entity.IsVerified, false).ToListAsync());

            if (accountListAccept.Any())
            {
                foreach (var account in accountListAccept)
                {
                    account.IsVerified = true;

                    account.VerifiedBy = verifier;

                    _repository.Account.Update(account);

                    await _repository.Save();
                }
            }
            if (accountListReject.Any())
            {
                foreach(var account in accountListReject)
                {
                    await _userManager.DeleteAsync(account);
                }
            }
        }
        public async Task<(IEnumerable<AccountNeedVerifyResponseModel> data, MetaData meta)> GetVerifierAccounts(NeedVerifyParameters param, string userId)
        {
            var user = await _repository.Account.FindWithVerifierId(param) ?? throw new BadRequestException("bad param");

            return (_mapper.Map<IEnumerable<AccountNeedVerifyResponseModel>>(user), user.MetaData);
        }
        public async Task<(IEnumerable<AccountNeedVerifyResponseModel> data, MetaData meta)> GetVerifierAccountsSuper(NeedVerifyParameters param, string userId)
        {
            var hold = !string.IsNullOrWhiteSpace(param.Role) ?  _userManager.GetUsersInRoleAsync(param.Role).Result.Where(x => !x.IsVerified) : null;

            List<string> validGuid = new List<string>();

            if (hold != null && hold.Any())

                foreach (var item in hold)

                    validGuid.Add(item.Id.ToString());


            var user = await _repository.Account.FindWithVerifierIdSuper(param, validGuid, userId) ?? throw new BadRequestException("bad param");

            return (_mapper.Map<IEnumerable<AccountNeedVerifyResponseModel>>(user), user.MetaData);
        }

        public async Task<IEnumerable<AccountReturnModel>> GetUserByRole(string role) => _mapper.Map<IEnumerable<AccountReturnModel>>((await _userManager.GetUsersInRoleAsync(role)).Where(x => x.IsVerified));
        public async Task<IEnumerable<MinorAccountReturnModel>> GetAccountNameWithRole(string role) => _mapper.Map<IEnumerable<MinorAccountReturnModel>>((await _userManager.GetUsersInRoleAsync(role)).Where(x => x.IsVerified));
        public async Task<bool> ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            var user = await _repository.Account.GetByConditionAsync(entity => entity.Id.Equals(userId), true);
            var account = user.FirstOrDefault();
            if (account != null)
            {
                var result = await _userManager.ChangePasswordAsync(account, oldPassword, newPassword);
                return result.Succeeded;
            }
            else throw new BadRequestException("User with id: " + userId + " is not exist");
        }

        public async Task UpdateProfileAsync(UpdateProfileRequestModel model)
        {
            try
            {
                var user = await _repository.Account.GetByConditionAsync(entity => entity.Id.Equals(model.Id), true);

                var account = user.FirstOrDefault();

                if (account == null) throw new BadRequestException("User with id: " + model.Id + " is not exist");

                account.FullName = model.FullName;

                var checkRole = await _userManager.GetRolesAsync(account);
                var roleName = checkRole.FirstOrDefault();
                if (roleName == null) throw new BadRequestException($"{roleName} is not valid");

                var hold = await _repository.StudentDetail.GetByConditionAsync(entity => entity.AccountId != null && entity.AccountId.Equals(model.Id), true);
                var studentDetail = hold.FirstOrDefault();

                if (studentDetail == null)
                {
                    var newStudentDetail = new StudentDetail() { AccountId = model.Id, RollNumber = account.UserName, Major = model.Major, Specialized = model.Specialized };
                    await _repository.StudentDetail.CreateAsync(newStudentDetail);
                }
                else
                {
                    studentDetail.Major = model.Major;
                    studentDetail.Specialized = model.Specialized;
                    _repository.StudentDetail.Update(studentDetail);
                }
                account.Gender = model.Gender;
                account.FullName = model.FullName;
                _repository.Account.Update(account);
                await _repository.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exceptions Occur at service {nameof(UpdateProfileAsync)} with the message" + ex.Message);
            }
        }

        public async Task ChangeEmailAsync(string id, ChangeEmailRequestModel model)
        {
            var user = await _repository.Account.GetByCondition(entity => entity.Id.Equals(id), true).FirstOrDefaultAsync();

            if (user == null) throw new BadRequestException($"Can't find user with id: ${id}");

            user.Email = model.Email;

            await _repository.Save();
        }

        public async Task<IEnumerable<AccountRequestJoinResponseModel>> GetUserWithRole(string role)
        {
            var hold = await _userManager.GetUsersInRoleAsync(role);

            return _mapper.Map<IEnumerable<AccountRequestJoinResponseModel>>(hold);
        }

        public async Task<int> CountMember()
        {
            var hold = await _repository.Account.GetByCondition(x => x.IsBanned == false && x.IsDeleted == false && x.IsVerified == true, false).ToListAsync();
            return hold.Count;
        }

        public async Task<MemberReportModel> GetActiveMember()
        {
            var hold_member = await _repository.Account.GetByCondition(x => x.IsBanned == false && x.IsDeleted == false && x.IsVerified == true, false).CountAsync();
            var hold_online = await _repository.Account.GetByCondition(x => x.LoginSessionAge.CompareTo(DateTime.UtcNow) > 0, false).CountAsync();
            return new MemberReportModel {Online = hold_online, Offline = hold_member - hold_online };
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
