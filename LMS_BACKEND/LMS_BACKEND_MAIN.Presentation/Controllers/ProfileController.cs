using Entities.Exceptions;
using LMS_BACKEND_MAIN.Presentation.Attributes;
using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestModel model)
        {
            await _service.AccountService.ChangePasswordAsync(model.UserID, model.OldPassword, model.NewPassword);
            return Ok(new ResponseMessage { Message = "Change Password Successully" });
        }

        [HttpPost(RoutesAPI.ChangeEmail)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ChangeEmail(string id)
        {
            if (!CheckUser().Equals(id)) throw new BadRequestException("user don't have the right to function");
            var hold = await _service.AccountService.GetUserById(id);
            var email = hold.Email;
            if (await _service.MailService.SendOTP(email, "ChangeEmailKey"))
            {
                return Ok(new ResponseMessage { Message = "Change email successfully" });
            }
            return BadRequest(new ResponseMessage { Message = "User not found or wrong verify code" });
        }

        [HttpPost(RoutesAPI.ChangeEmailOtp)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ChangeEmailOtp(string id, ChangeEmailRequestModel model)
        {
            if (!CheckUser().Equals(id)) throw new BadRequestException("user don't have the right to function");
            var hold = await _service.AccountService.GetUserById(id);
            var email = hold.Email;
            if (await _service.MailService.VerifyOtp(email, model.Token, "ChangeEmailKey"))
            {
                await _service.AccountService.ChangeEmailAsync(id, model);

                return Ok(new ResponseMessage { Message = "Change email successfully" });
            }
            return BadRequest(new ResponseMessage { Message = "User not found or wrong verify code" });
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        public async Task<IActionResult> UpdateProfile(string id, [FromBody] UpdateProfileRequestModel model)
        {
            await _service.AccountService.UpdateProfileAsync(id, model);

            return Ok(new ResponseMessage { Message = "Update Profile Successully" });
        }
        private async Task<string> CheckUser()
        {
            var userClaims = User.Claims;

            var username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            var hold = await _service.AccountService.GetUserByName(username ?? throw new UnauthorizedException("lamao"));

            return hold.Id;
        }

        [HttpGet(RoutesAPI.GetProjectWithMember)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        public IActionResult GetProjectWithMember(string userId)
        {
            var data = _service.ProjectService.GetProjects(userId);
            return Ok(data);
        }
    }
}
