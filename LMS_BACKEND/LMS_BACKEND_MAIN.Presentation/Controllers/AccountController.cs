
using Entities.Models;
using LMS_BACKEND_MAIN.Presentation.Attributes;
using LMS_BACKEND_MAIN.Presentation.Dictionaries;
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
    [Route(APIs.AccountAPI)]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AccountController(IServiceManager service)
        {
            _service = service;
        }

        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear, Roles = Roles.ADMIN)]
        [HttpPost(RoutesAPI.CreateAdmin)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateAdmin([FromBody] RegisterRequestModel model)
        {
            var result = await _service.AuthenticationService.RegisterLabLead(model);

            await _service.MailService.SendVerifyOtp(model.Email ?? "");

            return StatusCode(201, result);
        }


        [HttpGet(RoutesAPI.GetUsers)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear, Roles = Roles.ADMIN)]
        public async Task<IActionResult> GetUsers(string role)
        {
            var hold = await _service.AccountService.GetUserByRole(role.ToUpper());

            return Ok(hold);
        }

        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear, Roles = Roles.ADMIN)]
        [HttpGet(RoutesAPI.GetAccountNeedVerified)]
        public IActionResult GetAccountNeedVerified(string email)
        {
            var user =
            _service.AccountService.GetVerifierAccounts(email);
            return Ok(new { Status = "success", Value = user });
        }

        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear, Roles = Roles.SUPERVISOR)]
        [HttpPost(RoutesAPI.UpdateAccountVerifyStatus)]
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
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> GetAccountDetail(string id)
        {
            var data = await _service.AccountService.GetAccountDetail(id);
            return Ok(new { Status = "success", Value = data });
        }


        [HttpPost(RoutesAPI.ChangePassword)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
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


        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ResponseCache(Duration = 60)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        public async Task<IActionResult> UpdateProfile(string id, [FromBody] UpdateProfileRequestModel model)
        {
            await _service.AccountService.UpdateProfileAsync(id, model);

            return Ok(new ResponseMessage { Message = "Update Profile Successully" });
        }
    }
}
