
using Entities.Models;
using LMS_BACKEND_MAIN.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AccountController(IServiceManager service)
        {
            _service = service;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "LabAdmin")]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterLabLead([FromBody] RegisterRequestModel model)
        {
            var result = await _service.AuthenticationService.RegisterLabLead(model);

            await _service.MailService.SendVerifyOtp(model.Email ?? "");

            return StatusCode(201, result);
        }


        [HttpGet("accounts/{role}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "LabAdmin")]
        public async Task<IActionResult> GetUsers(string role)
        {

            var hold = await _service.AccountService.GetUserByRole(role.ToUpper());

            if (hold != null)
            {
                return Ok(hold.Where(x => x.IsVerified = true));
            }

            return NotFound(new ResponseMessage { Message = "Not found any user!" });
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Supervisor")]
        [HttpGet("need-verified")]
        public IActionResult GetAccountNeedVerified(string email)
        {
            var user =
            _service.AccountService.GetVerifierAccounts(email);
            return Ok(new { Status = "success", Value = user });
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Supervisor")]
        [HttpPost("verify-account")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateAccountVerifyStatus([FromBody] UpdateVerifyStatusRequestModel model)
        {

            var user = await _service.AccountService.GetUserById(model.UserID);

            if (user == null)
            {
                return NotFound(new ResponseMessage { Message = "User Not Found" });
            }

            var hold = new List<string> { model.UserID };
            await _service.AccountService.UpdateAccountVerifyStatus(hold, model.verifierID);
            return Ok(new ResponseMessage { Message = "Update User " + user.FullName + " Status Successully" });
        }

        [HttpPost("change-password")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestModel model)
        {
            await _service.AccountService.ChangePasswordAsync(model.UserID, model.OldPassword, model.NewPassword);
            return Ok(new ResponseMessage { Message = "Change Password Successully" });
        }

        /*[HttpPut("change-phone-number")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> ChangeEmail([FromBody] ChangePhoneNumberRequestModel model)
        {
            if (await _service.AccountService.ChangePasswordAsync(model.UserID, model.OldPassword, model.NewPassword))
            {
                return Ok(new ResponseObjectModel { Status = "success", Code = 200", Value = "Change Password Successully" });
            }           
        }*/

        [HttpPut("update-profile")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequestModel model)
        {

            await _service.AccountService.UpdateProfileAsync(model.UserID, model.FullName, model.RollNumber, model.Major, model.Specialized);
                    return Ok(new ResponseMessage { Message = "Update Profile Successully" });

        }
    }
}
