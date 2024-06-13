using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Shared;
using Shared.DataTransferObjects.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterSupervisor(RegisterRequestModel model);
        Task<IdentityResult> RegisterLabLead(RegisterRequestModel model);
        Task<IdentityResult> RegisterStudent(RegisterRequestModel studentRegisterRequestModel);
        Task<bool> ValidateUser(LoginRequestModel loginRequestModel);
        Task<string> CreateToken();
        Task<TokenDTO> CreateToken(bool populateExpiration);
        Task<TokenDTO> RefreshToken(TokenDTO tokenDTO);
        Task<bool> InvalidateToken(TokenDTO tokenDTO);
    }
}
