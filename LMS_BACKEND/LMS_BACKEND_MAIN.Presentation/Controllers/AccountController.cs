
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
        //[Authorize(AuthenticationSchemes = "Bearer")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> GetAccountDetail(string id)
        {
            var data = await _service.AccountService.GetAccountDetail(id);
            return Ok(data);
        }


        [HttpPost(RoutesAPI.ChangePassword)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestModel model)
        {
            await _service.AccountService.ChangePasswordAsync(model.UserID, model.OldPassword, model.NewPassword);
            return Ok(new ResponseMessage { Message = "Change Password Successully" });
        }

        [HttpPost(RoutesAPI.ChangeEmail)]
        //[Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ChangeEmail(string id, [FromBody] ChangeEmailRequestModel model)
        {
            //var hold = await _service.AccountService.GetUserById(id);
            //var email = hold.Email;
            //if (await _service.MailService.SendOTP(email, "ChangeEmailKey"))
            //{
            //    return Ok(new ResponseMessage { Message = "OTP SENT TO USER EMAIL" });
            //}
            //return BadRequest(new ResponseMessage { Message = "Invalid email" });
            await _service.AccountService.ChangeEmailAsync(id, model);
            return Ok(new ResponseMessage { Message = "Change email Successully" });
        }

        //[HttpPost(RoutesAPI.ChangeEmailOtp)]
        //[Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        //public async Task<IActionResult> ChangeEmailOtp(string id, [FromBody] ChangeEmailRequestModel model)
        //{
        //    var hold = await _service.AccountService.GetUserById(id);
        //    var email = hold.Email;
        //    if (await _service.MailService.VerifyOtp(email, model.VerifyCode, "ChangeEmailKey"))
        //    {

        //        return Ok(new ResponseMessage { Message = "Change email successfully" });
        //    }
        //    return BadRequest(new ResponseMessage { Message = "User not found or wrong verify code" });
        //}

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
