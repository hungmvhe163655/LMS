using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using System.Security.Claims;

namespace Service.Contracts
{
    public interface IAccountService
    {
        Task ChangeVerifierForId(string id, string verifierId);

        Task<string> CheckUser(ClaimsPrincipal user);

        Task<IEnumerable<MinorAccountReturnModel>> GetAccountNameWithRole(string role);

        Task<IEnumerable<AccountReturnModel>> GetUserByRole(string role);

        Task<AccountReturnModel> GetUserByName(string userName);

        Task<AccountReturnModel> GetUserByEmail(string email, bool Verified);

        Task<AccountReturnModel> GetUserById(string id);

        Task<(IEnumerable<AccountNeedVerifyResponseModel> data, MetaData meta)> GetVerifierAccounts(NeedVerifyParameters param, string userId);

        Task<(IEnumerable<AccountNeedVerifyResponseModel> data, MetaData meta)> GetVerifierAccountsSuper(NeedVerifyParameters param, string userId);

        Task UpdateAccountVerifyStatus(IEnumerable<UserAcceptanceRequestModel> userIdList, string verifier);

        Task<bool> ChangePasswordAsync(string userId, string oldPassword, string newPassword);

        Task UpdateProfileAsync(UpdateProfileRequestModel model);

        Task<AccountDetailResponseModel> GetAccountDetail(string userId);

        Task ChangeEmailAsync(string id, ChangeEmailRequestModel model);

        Task<IEnumerable<AccountRequestJoinResponseModel>> GetUserWithRole(string role);
        Task<int> CountMember(string type);
    }
}