using LMS_BACKEND_MAIN.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController(IServiceManager serviceManager)
        {
            _service = serviceManager;
        }
        [HttpPost("Register")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize]
        public async Task<IActionResult> RegisterLabLead([FromBody] RegisterRequestModel model)
        {
            try
            {
                var result = await _service.AuthenticationService.RegisterLabLead(model);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await _service.MailService.SendVerifyOtp(model.Email);

                return StatusCode(201, new ResponseObjectModel { Code = "201", Status = "Success", Value = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = "500", Status = $"Internal error at {nameof(RegisterLabLead)}" });
            }
        }
        [HttpPut("ReSendVerifyEmail")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ReSendVerifyEmail([FromBody] MailRequestModel model)
        {
            if (model.Email == null)
            {
                return BadRequest("Email can't be empty");
            }
            if (await _service.MailService.SendVerifyOtp(model.Email))
            {
                return Ok("New Verify code Has been sent to your email");
            }
            return BadRequest("Wrong request");
        }
        [HttpPut("VerifyEmail")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> VerifyEmail([FromBody] MailRequestModel model)
        {
            var email = model.Email;
            var token = model.AuCode;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            {
                return BadRequest("Empty email or token");
            }
            if (await _service.AuthenticationService.VerifyEmail(email, token))
            {
                return Ok("Success");
            }
            return BadRequest("Invalid Token");
        }
        [HttpPost("RegisterSupervisor")]
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
                    return BadRequest(new ResponseObjectModel { Code = "401", Status = "Error while trying to create Supervisor", Value = ModelState });
                }
                await _service.MailService.SendVerifyOtp(model.Email);

                return StatusCode(201, new ResponseObjectModel { Code = "201", Status = "Create User Successfully", Value = model });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = "500", Status = $"Internal error at {nameof(RegisterSupervisor)}" });
            }
        }
        [HttpPost("RegisterStudent")]
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
                    return BadRequest(ModelState);
                }
                await _service.MailService.SendVerifyOtp(model.Email);

                return StatusCode(201, new ResponseObjectModel { Code = "201", Status = "Create User Successfully", Value = model });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = "500", Status = $"Internal error at {nameof(RegisterStudent)}" });
            }
        }
        [HttpPost("Login-2factor")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate2Factor([FromBody] LoginRequestModel model)
        {
            try
            {
                if (await _service.MailService.VerifyTwoFactorOtp(model.Email, model.AuCode))
                {
                    string outcome = await _service.AuthenticationService.ValidateUser(model);
                    var Tokendto = await _service.AuthenticationService.CreateToken(true);
                    return Ok(Tokendto);
                }
                return BadRequest("Wrong code");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = "500", Status = $"Internal error at {nameof(Authenticate2Factor)}" });

            }
        }
        private async Task<IActionResult> LoginProcess(string outcome, bool twofactor, LoginRequestModel model)
        {
            try
            {
                if (outcome.Split("|")[0].Equals("BADLOGIN"))
                {
                    return Unauthorized(new ResponseObjectModel { Code = "401", Status = "Login Failed", Value = "Wrong password or email" });
                }
                if (outcome.Split("|")[0].Equals("UNVERIFIED"))
                {
                    return Unauthorized(new ResponseObjectModel { Code = "401", Status = "Login Failed", Value = "Account NeedVerify|" + outcome.Split("|")[1] });
                }
                if (outcome.Split("|")[0].Equals("UNVERIFIEDEMAIL"))
                {
                    return Unauthorized(new ResponseObjectModel { Code = "401", Status = "Login Failed", Value = "Email Need Verify|" + outcome.Split("|")[1] });
                }
                if (outcome.Split("|")[0].Equals("ISBANNED"))
                {
                    return Unauthorized(new ResponseObjectModel { Code = "401", Status = "Account is banned" });
                }
                if (outcome.Split("|")[0].Equals("SUCCESS"))
                {
                    if (twofactor)
                    {
                        if (await _service.MailService.SendTwoFactorOtp(model.Email))
                        {
                            return Ok(new ResponseObjectModel { Code = "200", Status = "TwoFactorSuccess", Value = "2 Factor code was sent" });
                        }
                        return BadRequest(new ResponseObjectModel { Code = "400", Value = "Bad Login", Status = "Login Failed" });
                    }
                    else
                    {
                        var Tokendto = await _service.AuthenticationService.CreateToken(true);
                        return Ok(Tokendto);
                    }
                }
                return NotFound(new ResponseObjectModel { Code = "404", Status = "Not found", Value = "email or password was wrong" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = "500", Status = $"Internal error at {nameof(LoginProcess)}" });

            }
        }
        [HttpPost("Login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequestModel model)
        {
            try
            {
                string outcome = await _service.AuthenticationService.ValidateUser(model);
                var user = await _service.AccountService.GetUserByEmail(model.Email);
                return await LoginProcess(outcome, user.TwoFactorEnabled, model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = "500", Status = $"Internal error at {nameof(Authenticate)}" });

            }
        }
        [HttpPost("Logout")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Logout([FromBody] TokenDTO model)
        {
            if (!await _service.AuthenticationService.InvalidateToken(model))
            {
                return Unauthorized(new ResponseObjectModel { Code = "401", Value = "Invalid Token", Status = "Failed" });
            }
            return Ok(new ResponseObjectModel { Code="200", Value="", Status="Logout Success"});
        }
        [HttpPost("ForgotPassword")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestModel model)
        {
            if (await _service.MailService.SendForgotPasswordOtp(model.Email, model.PhoneNumber))
            {
                return Ok("OTP SENT TO USER EMAIL/PHONE");
            }
            return BadRequest("Invalid email/phonenumber");
        }
        [HttpPost("ForgotPasswordOtp")]
        public async Task<IActionResult> ForgotPasswordOtp([FromBody] ForgotPasswordRequestModel model)
        {
            if (string.IsNullOrEmpty(model.VerifyCode) || string.IsNullOrEmpty(model.Email))
            {
                return BadRequest("empty verify code/ Email");
            }
            if (await _service.MailService.VerifyForgotPasswordOtp(model.Email, model.VerifyCode))
            {
                return Ok(model.Email);
            }
            return BadRequest("User not found or wrong verify code");
        }
    }
}
