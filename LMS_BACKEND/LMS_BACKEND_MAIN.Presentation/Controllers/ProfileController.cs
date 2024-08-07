﻿using Entities.Exceptions;
using LMS_BACKEND_MAIN.Presentation.Attributes;
using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System.Security.Claims;
namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route(APIs.ProfileAPI)]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ProfileController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost(RoutesAPI.ChangePassword)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ChangePassword(string id, [FromBody] ChangePasswordRequestModel model)
        {
            if (_service.AccountService.CheckUser(User).Result.Equals(id)) throw new BadRequestException("user don't have the right to function");

            var account = await _service.AccountService.GetUserById(id);

            await _service.MailService.SendOTP(account.Email, "ChangePasswordKey");

            return Ok(new ResponseMessage { Message = "Change Password Successully" });
        }
        [HttpPost(RoutesAPI.ChangePasswordOtp)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ChangePasswordOtp(string id, [FromBody] ChangePasswordRequestModel model)
        {
            if (string.IsNullOrWhiteSpace(id)) return BadRequest(ModelState);

            if (_service.AccountService.CheckUser(User).Result.Equals(id)) throw new BadRequestException("user don't have the right to function");

            var account = await _service.AccountService.GetUserById(id);

            if (await _service.MailService.VerifyOtp(account.Email, model.Token ?? "-", "ChangePasswordKey"))
            {
                await _service.AccountService.ChangePasswordAsync(id, model.OldPassword, model.NewPassword);

                return Ok(new ResponseMessage { Message = "Change password successfully" });
            }
            return BadRequest(new ResponseMessage { Message = "wrong verify code or password" });
        }

        [HttpPost(RoutesAPI.ChangeEmail)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ChangeEmail(string id, [FromBody] ChangeEmailRequestModel model)
        {
            if (_service.AccountService.CheckUser(User).Result.Equals(id)) throw new BadRequestException("user don't have the right to function");

            if (await _service.AccountService.GetUserByEmail(model.Email, false) != null) throw new BadRequestException("user with that email is already existed");

            if (await _service.MailService.SendOTP(model.Email, "ChangeEmailKey"))

                return Ok(new ResponseMessage { Message = "Change email successfully" });

            return BadRequest(new ResponseMessage { Message = "User not found or wrong verify code" });
        }

        [HttpPost(RoutesAPI.ChangeEmailOtp)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ChangeEmailOtp(string id, [FromBody] ChangeEmailRequestModel model)
        {
            if (_service.AccountService.CheckUser(User).Result.Equals(id)) throw new BadRequestException("user don't have the right to function");

            if (await _service.AccountService.GetUserByEmail(model.Email, false) != null) throw new BadRequestException("user with that email is already existed");

            if (await _service.MailService.VerifyOtp(model.Email, model.Token ?? "-", "ChangeEmailKey"))
            {
                await _service.AccountService.ChangeEmailAsync(id, model);

                return Ok(new ResponseMessage { Message = "Change email successfully" });
            }
            return BadRequest(new ResponseMessage { Message = "User not found or wrong verify code" });
        }

        [HttpPut]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequestModel model)
        {
            await _service.AccountService.UpdateProfileAsync(model);

            return Ok(new ResponseMessage { Message = "Update Profile Successully" });
        }
    }
}
