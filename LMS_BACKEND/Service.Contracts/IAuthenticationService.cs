using Shared;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<AccountReturnModel> Register(RegisterRequestModel model);
        //Task<bool> VerifyEmail(string email, string token);
        Task<AccountReturnModel> RegisterLabLead(RegisterRequestModel model);
        Task<HiddenAccountResponseModel> ValidateUser(LoginRequestModel userForAuth);
        Task<string> CreateToken();
        Task<TokenDTO> CreateToken(bool populateExpiration);
        Task<TokenDTO> RefreshTokens(TokenDTO tokenDTO);
        Task<bool> InvalidateToken(TokenDTO tokenDTO);
        Task<string> ForgotPassword(string email);
    }
}
