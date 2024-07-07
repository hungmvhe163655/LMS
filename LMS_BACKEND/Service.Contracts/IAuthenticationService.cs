using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Shared;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<AccountReturnModel> Register(RegisterRequestModel model);
        //Task<bool> VerifyEmail(string email, string token);
        Task<AccountReturnModel> RegisterLabLead(RegisterRequestModel model);
        Task<string> ValidateUser(LoginRequestModel loginRequestModel);
        Task<string> CreateToken();
        Task<TokenDTO> CreateToken(bool populateExpiration);
        Task<TokenDTO> RefreshTokens(TokenDTO tokenDTO);
        Task<bool> InvalidateToken(TokenDTO tokenDTO);
    }
}
