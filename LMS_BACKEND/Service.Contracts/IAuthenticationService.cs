using Entities.Models;
using Microsoft.AspNetCore.Identity;
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
        Task<IdentityResult> RegisterStudent(StudentRegisterRequestModel studentRegisterRequestModel);
    }
}
