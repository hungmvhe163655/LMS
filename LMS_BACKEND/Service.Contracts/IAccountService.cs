using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface IAccountService
    {
        Task ChangeVerifierForId(string id, string verifierId);
        Task<IEnumerable<MinorAccountReturnModel>> GetAccountNameWithRole(string role);
        Task<IEnumerable<AccountReturnModel>> GetUserByRole(string role);
        Task<AccountReturnModel> GetUserByName(string userName);
        Task<AccountReturnModel> GetUserByEmail(string email, bool Verified);
        Task<AccountReturnModel> GetUserById(string id);
        Task<(IEnumerable<AccountNeedVerifyResponseModel> data, MetaData meta)> GetVerifierAccounts(NeedVerifyParameters param);
        Task<bool> UpdateAccountVerifyStatus(IEnumerable<string> userIdList, string verifier);
        Task<bool> ChangePasswordAsync(string userId, string oldPassword, string newPassword);
        Task UpdateProfileAsync(UpdateProfileRequestModel model);
        Task<AccountDetailResponseModel> GetAccountDetail(string userId);
        Task ChangeEmailAsync(string id, ChangeEmailRequestModel model);
    }
}