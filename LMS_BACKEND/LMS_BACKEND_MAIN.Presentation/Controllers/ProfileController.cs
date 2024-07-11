using Entities.Exceptions;
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
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestModel model)
        {
            await _service.AccountService.ChangePasswordAsync(model.UserID, model.OldPassword, model.NewPassword);
            return Ok(new ResponseMessage { Message = "Change Password Successully" });
        }

        [HttpPost(RoutesAPI.ChangeEmail)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ChangeEmail(string id, [FromBody] ChangeEmailRequestModel model)
        {
            if (!CheckUser().Equals(id)) throw new BadRequestException("user don't have the right to function");

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
            if (!CheckUser().Equals(id)) throw new BadRequestException("user don't have the right to function");

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
