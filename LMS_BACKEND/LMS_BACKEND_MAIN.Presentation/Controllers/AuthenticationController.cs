using LMS_BACKEND_MAIN.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.VisualBasic;
using Service.Contracts;
using Shared;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
            if (model.Email == null)
            {
                return BadRequest(new ResponseObjectModel { Code = "400", Status = "Failed", Value = "Email can't be empty" });
            }
            if (await _service.MailService.SendVerifyOtp(model.Email))
            {
                return Ok(new ResponseObjectModel { Code = "200", Status = "Success", Value = "New Verify code Has been sent to your email" });
            }
            return BadRequest(new ResponseObjectModel { Code = "400", Status = "Failed", Value = "Wrong request" });
        }
        [HttpPut("verify-email")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> VerifyEmail([FromBody] MailRequestModel model)
        {
            var email = model.Email;
            var token = model.AuCode;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            {
                return BadRequest(new ResponseObjectModel { Code = "400", Status = "Failed", Value = "Empty email or token" });
            }
            if (await _service.AuthenticationService.VerifyEmail(email, token))
            {
                return Ok(new ResponseObjectModel { Code = "200", Status = "Success", Value = model.Email });
            }
            return BadRequest(new ResponseObjectModel { Code = "400", Status = "Failed", Value = "Invalid Token" });
        }
        [HttpPost("register-supervisor")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterSupervisor([FromBody] RegisterRequestModel model)
        {
            try
            {
                var result = await

           _service.AuthenticationService.Register(model);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }
                    return BadRequest(new ResponseObjectModel { Code = "400", Status = "Failed", Value = new { Message = "Model " } });
                }
                await _service.MailService.SendVerifyOtp(model.Email ?? "");

                return StatusCode(201, new ResponseObjectModel { Code = "201", Status = "Success", Value = model });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = "500", Status = "Internal Error", Value = new { Message = $"Internal error at {nameof(RegisterSupervisor)}" + ex } });
            }
        }
        [HttpPost("register")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterRequestModel model)
        {
            try
            {
                var result = await

           _service.AuthenticationService.Register(model);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }
                    return BadRequest(new ResponseObjectModel { Code = "400", Status = "Failed", Value = "Bad User Detail`" });
                }
                await _service.MailService.SendVerifyOtp(model.Email ?? "");

                return StatusCode(201, new ResponseObjectModel { Code = "201", Status = "Succes", Value = model });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = "500", Status = "Internal Error", Value = new { Message = $"Internal error at {nameof(RegisterStudent)}" + ex } });
            }
        }
        [HttpPost("login-2factor")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate2Factor([FromBody] LoginRequestModel model)
        {
            try
            {
                if (model.Email != null && model.AuCode != null && await _service.MailService.VerifyTwoFactorOtp(model.Email, model.AuCode))
                {
                    string outcome = await _service.AuthenticationService.ValidateUser(model);
                    var Tokendto = await _service.AuthenticationService.CreateToken(true);
                    return Ok(new ResponseObjectModel { Code = "200", Status = "Success", Value = Tokendto });
                }
                return BadRequest(new ResponseObjectModel { Code = "400", Status = "Failed", Value = "Wrong code" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = "500", Status = "Internal Error", Value = new { Message = $"Internal error at {nameof(Authenticate2Factor)}" + ex } });
            }
        }
        private async Task<IActionResult> LoginProcess(string outcome, bool twofactor, AccountDTOforReturn model)
        {
            try
            {   
                if (outcome.Split("|")[0].Equals("SUCCESS"))
                {
                    if (twofactor)
                    {
                        if (await _service.MailService.SendTwoFactorOtp(model.email ?? ""))
                        {
                            return Ok(new ResponseObjectModel { Code = "200", Status = "Success", Value = "2 Factor code was sent" });
                        }
                        return BadRequest(new ResponseObjectModel { Code = "400", Value = "Bad Login", Status = "Failed" });
                    }
                    var Tokendto = await _service.AuthenticationService.CreateToken(true);

                    return Ok(new ResponseObjectModel { Code = "200", Status = "Success", Value = Tokendto });
                }
                else
                {
                    return Unauthorized(new ResponseObjectModel { Code = "401", Status = "Failed", Value = outcome });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = "500", Status = "Internal Error", Value = new { Message = $"Internal error at {nameof(LoginProcess)}" + ex } });
            }
        }
        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequestModel model)
        {
            try
            {
                if (model.Email == null) return BadRequest(new ResponseObjectModel { Code = "400", Status = "Failed", Value = "Email can't be null" });

                string outcome = await _service.AuthenticationService.ValidateUser(model);

                var user = await _service.AccountService.GetUserByEmail(model.Email);

                if (user.Any()) return await LoginProcess(outcome, user.First().TwoFactorEnabled, new AccountDTOforReturn(user.First().Id, model.Email, ""));

                return await LoginProcess(outcome, false, new AccountDTOforReturn("", "", ""));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = "500", Status = "Internal Error", Value = new { Message = $"Internal error at {nameof(Authenticate)}" + ex } });

            }
        }
        [HttpPost("logout")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Logout([FromBody] TokenDTORequestModel model)
        {
            var hold = new TokenDTO(model.AccessToken ?? "", model.RefreshToken ?? "");
            if (!await _service.AuthenticationService.InvalidateToken(hold))
            {
                return Unauthorized(new ResponseObjectModel { Code = "401", Value = "Invalid Token", Status = "Failed" });
            }
            return Ok(new ResponseObjectModel { Code = "200", Value = "", Status = "Logout Success" });
        }
        [HttpPost("forgot-password")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestModel model)
        {
            if (model.Email != null && await _service.MailService.SendOTP(model.Email, "ForgotPasswordKey"))
            {
                return Ok(new ResponseObjectModel { Code = "200", Status = "Success", Value = "\"OTP SENT TO USER EMAIL/PHONE\"" });
            }
            return BadRequest(new ResponseObjectModel { Code = "400", Status = "Failed", Value = "Invalid email/phonenumber" });
        }
        [HttpPost("forgot-password-otp")]
        public async Task<IActionResult> ForgotPasswordOtp([FromBody] ForgotPasswordRequestModel model)
        {
            if (string.IsNullOrEmpty(model.VerifyCode) || string.IsNullOrEmpty(model.Email))
            {
                return BadRequest(new ResponseObjectModel { Code = "400", Status = "Failed", Value = "empty verify code/ Email" });
            }
            if (await _service.MailService.VerifyOtp(model.Email, model.VerifyCode, "ForgotPasswordKey"))
            {
                return Ok(new ResponseObjectModel { Code = "200", Status = "Success", Value = model.Email });
            }
            return BadRequest(new ResponseObjectModel { Code = "400", Status = "Failed", Value = "User not found or wrong verify code" });
        }
        [HttpGet("me")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetCurrentLoggedInUser()
        {
            var userClaims = User.Claims;
            var userId = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var email = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            try
            {
                if (userId != null)
                {
                    var result = await _service.AccountService.GetUserById(userId);
                    return Ok(new ResponseObjectModel { Code = "200", Status = "Success", Value = result });
                }
                if (email != null)
                {
                    var result = await _service.AccountService.GetUserByName(email);
                    return Ok(new ResponseObjectModel { Code = "200", Status = "Success", Value = result });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = "500", Status = "Internal Error", Value = new { Message = $"Internal error at {nameof(GetCurrentLoggedInUser)}" + ex } });
            }
            return Unauthorized(new ResponseObjectModel { Code = "401", Status = "Failed", Value = "Not found User" });
        }
    }
}
