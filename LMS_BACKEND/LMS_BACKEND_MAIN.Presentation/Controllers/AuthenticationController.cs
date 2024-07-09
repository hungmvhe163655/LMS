﻿using Entities.Exceptions;
using LMS_BACKEND_MAIN.Presentation.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System.Security.Claims;
using LMS_BACKEND_MAIN.Presentation.Dictionaries;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route(APIs.AuthenticationAPI)]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController(IServiceManager serviceManager)
        {
            _service = serviceManager;
        }
        [HttpGet(RoutesAPI.GetUsers)]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _service.AccountService.GetUserByRole("SUPERVISOR"));
        }

        [HttpPost(RoutesAPI.RegisterSupervisor)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterSupervisor([FromBody] RegisterRequestModel model)
        {
            _ = await _service.AuthenticationService.Register(model);

            var user = await _service.AccountService.GetUserByEmail(model.Email);

            return StatusCode(201, user);
        }

        [HttpPost(RoutesAPI.RegisterStudent)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterRequestModel model)
        {
            _ = await _service.AuthenticationService.Register(model);

            var user = await _service.AccountService.GetUserByEmail(model.Email);

            return StatusCode(201, user);
        }

        [HttpPost(RoutesAPI.Authenticate2Factor)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate2Factor([FromBody] LoginRequestModel model)
        {

            if (await _service.MailService.VerifyTwoFactorOtp(model.Email, model.AuCode ?? throw new BadRequestException("Aucode is null")))
            {
                _ = await _service.AuthenticationService.ValidateUser(model);

                var Tokendto = await _service.AuthenticationService.CreateToken(true);

                var user = await _service.AccountService.GetUserByEmail(model.Email);

                return Ok(new { TOKEN = Tokendto, User = user });
            }

            return BadRequest(new ResponseMessage { Message = "Wrong code" });

        }
        private async Task<IActionResult> LoginProcess(string outcome, bool twofactor, AccountReturnModel model)
        {
            if (outcome.Split("|")[0].Equals("SUCCESS"))
            {
                if (twofactor)
                {
                    if (await _service.MailService.SendTwoFactorOtp(model.Email ?? ""))
                    {
                        return Ok(new ResponseMessage { Message = "2 Factor code was sent" });
                    }
                    return BadRequest(new ResponseMessage { Message = "Can't send 2 Factor Authetication" });
                }
                var Tokendto = await _service.AuthenticationService.CreateToken(true);

                return Ok(new { TOKEN = Tokendto, User = model });
            }
            if (outcome.Split("|")[0].Equals("ISBANNED"))
            {
                return StatusCode(406, new ResponseMessage { Message = outcome });
            }
            return Unauthorized(new ResponseMessage { Message = outcome });
        }

        [HttpPost(RoutesAPI.Authenticate)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequestModel model)
        {
            string outcome = await _service.AuthenticationService.ValidateUser(model);

            var hold_2Factor = outcome.Split("|")[1].Equals("TWOFACTOR");

            var user = await _service.AccountService.GetUserByEmail(model.Email);

            return await LoginProcess(outcome, hold_2Factor, user);

        }

        [HttpPost(RoutesAPI.Logout)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Logout([FromBody] TokenDTORequestModel model)
        {
            var hold = new TokenDTO(model.AccessToken, model.RefreshToken);

            if (!await _service.AuthenticationService.InvalidateToken(hold))
            {
                return Unauthorized(new ResponseMessage { Message = "Something went wrong, can't logout!" });
            }
            return Ok(new ResponseMessage { Message = "Logout Success" });
        }

        [HttpPost(RoutesAPI.ForgotPassword)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestModel model)
        {
            var hold = await _service.AuthenticationService.ForgotPassword(model.Email);

            if (await _service.MailService.SendMailToUser(model.Email, $"Your new password is here: {hold} remember to login and change it soon !", "LMS - YOUR NEW PASSWORD"))
            {
                return Ok(new ResponseMessage { Message = "NEWPASSWORD WAS SENT TO USER EMAIL/PHONE" });
            }
            return BadRequest(new ResponseMessage { Message = "Invalid email/phonenumber" });
        }

        [HttpPost(RoutesAPI.VerifyEmailSend)]
        public async Task<IActionResult> VerifyEmailSend([FromBody] MailVerifyRequestModel model)
        {
            await _service.MailService.SendVerifyEmailOtp(model.Email);

            return Ok(new ResponseMessage { Message = "A Verify Code Has Been Sent to Your Email" });
        }

        [HttpPut(RoutesAPI.VerifyEmail)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> VerifyEmail([FromBody] MailRequestModel model)
        {
            if (await _service.AccountService.GetUserByEmail(model.Email) != null) throw new BadRequestException("User is already existed");

            if (_service.MailService.VerifyEmailOtp(model.Email, model.AuCode))
            {
                return Ok(new ResponseMessage { Message = "Email Verified Successfully" });
            }

            return BadRequest(new ResponseMessage { Message = "Invalid Token" });
        }

        [HttpGet(RoutesAPI.GetCurrentLoggedInUser)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        public async Task<IActionResult> GetCurrentLoggedInUser()
        {
            var userClaims = User.Claims;

            var userId = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            var email = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            if (userId != null)
            {
                var result = await _service.AccountService.GetUserById(userId);

                return Ok(result);
            }

            if (email != null)
            {
                var result = await _service.AccountService.GetUserByName(email);

                return Ok(result);
            }

            return Unauthorized(new ResponseMessage { Message = "User Not Found " });
        }
    }
}
