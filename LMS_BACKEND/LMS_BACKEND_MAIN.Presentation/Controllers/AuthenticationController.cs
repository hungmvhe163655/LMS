using LMS_BACKEND_MAIN.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System.Security.Claims;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController(IServiceManager serviceManager)
        {
            _service = serviceManager;
        }

        [HttpPut("resend-verify-email")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ReSendVerifyEmail([FromBody] MailRequestModel model)
        {
            if (await _service.MailService.SendVerifyOtp(model.Email))
            {
                return Ok(new ResponseMessage { Message = "A Verify Code Has Been Sent to Your Email" });
            }

            return BadRequest(new ResponseMessage { Message = "Something Went Wrong!" });
        }

        [HttpPut("verify-email")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> VerifyEmail([FromBody] MailRequestModel model)
        {
            var email = model.Email;
            var token = model.AuCode;

            if (await _service.AuthenticationService.VerifyEmail(email, token))
            {
                return Ok(model.Email);
            }

            return BadRequest(new ResponseMessage { Message = "Invalid Token" });
        }

        [HttpPost("register/supervisor")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterSupervisor([FromBody] RegisterRequestModel model)
        {
            var result = await _service.AuthenticationService.Register(model);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(new ResponseMessage { Message = "Model " + ModelState.Errors });
            }

            await _service.MailService.SendVerifyOtp(model.Email);

            return StatusCode(201, model);

        }

        [HttpPost("register/student")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterRequestModel model)
        {

            var result = await _service.AuthenticationService.Register(model);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(new ResponseMessage { Message = "Bad User Detail" });
            }

            await _service.MailService.SendVerifyOtp(model.Email);

            return StatusCode(201, model);


        }

        [HttpPost("login-2factor")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate2Factor([FromBody] LoginRequestModel model)
        {

            if (await _service.MailService.VerifyTwoFactorOtp(model.Email, model.AuCode))
            {
                string outcome = await _service.AuthenticationService.ValidateUser(model);
                var Tokendto = await _service.AuthenticationService.CreateToken(true);
                return Ok(Tokendto);
            }

            return BadRequest(new ResponseMessage { Message = "Wrong code" });

        }
        private async Task<IActionResult> LoginProcess(string outcome, bool twofactor, AccountDTOforReturn model)
        {

            if (outcome.Split("|")[0].Equals("SUCCESS"))
            {
                if (twofactor)
                {
                    if (await _service.MailService.SendTwoFactorOtp(model.email ?? ""))
                    {
                        return Ok(new ResponseMessage { Message = "2 Factor code was sent" });
                    }
                    return BadRequest(new ResponseMessage { Message = "Can't send 2 Factor Authetication" });
                }
                var Tokendto = await _service.AuthenticationService.CreateToken(true);

                return Ok(Tokendto);
            }

            return Unauthorized(outcome);


        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequestModel model)
        {

            if (model.Email == null) return BadRequest(new ResponseMessage { Message = "Email can't be null" });

            string outcome = await _service.AuthenticationService.ValidateUser(model);

            var user = await _service.AccountService.GetUserByEmail(model.Email);

            if (user.Any()) return await LoginProcess(outcome, user.First().TwoFactorEnabled, new AccountDTOforReturn(user.First().Id, model.Email, ""));

            return await LoginProcess(outcome, false, new AccountDTOforReturn("", "", ""));

        }

        [HttpPost("logout")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Logout([FromBody] TokenDTORequestModel model)
        {
            var hold = new TokenDTO(model.AccessToken , model.RefreshToken);
            if (!await _service.AuthenticationService.InvalidateToken(hold))
            {
                return Unauthorized(new ResponseMessage { Message = "Something went wrong, can't logout!");
            }
            return Ok(new ResponseMessage { Message = "Logout Success" });
        }

        [HttpPost("forgot-password")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestModel model)
        {
            if (await _service.MailService.SendOTP(model.Email, "ForgotPasswordKey"))
            {
                return Ok(new ResponseMessage { Message = "OTP SENT TO USER EMAIL/PHONE" });
            }
            return BadRequest(new ResponseMessage { Message = "Invalid email/phonenumber" });
        }

        [HttpPost("forgot-password-otp")]
        public async Task<IActionResult> ForgotPasswordOtp([FromBody] ForgotPasswordRequestModel model)
        {
            if (await _service.MailService.VerifyOtp(model.Email, model.VerifyCode, "ForgotPasswordKey"))
            {
                return Ok(model.Email);
            }
            return BadRequest(new ResponseMessage { Message = "User not found or wrong verify code" });
        }

        [HttpGet("me")]
        [Authorize(AuthenticationSchemes = "Bearer")]
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
