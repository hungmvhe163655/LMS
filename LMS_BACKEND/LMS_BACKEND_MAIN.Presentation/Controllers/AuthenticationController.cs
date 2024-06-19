using LMS_BACKEND_MAIN.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared;
using Shared.DataTransferObjects.RequestDTO;
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

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);

            }
        }
        [HttpPut("ReSendVerifyEmail")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ReSendVerifyEmail([FromBody] SimpleRequestModel model)
        {
            if (model.Propety1 == null)
            {
                return BadRequest("Email can't be empty");
            }
            if (await _service.MailService.SendVerifyOtp(model.Propety1))
            {
                return Ok("New Verify code Has been sent to your email");
            }
            return BadRequest("Wrong request");
        }
        [HttpPut("VerifyEmail")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> VerifyEmail([FromBody] SimpleRequestModel model)
        {
            var email = model.Propety1;
            var token = model.Propety2;
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

           _service.AuthenticationService.RegisterSupervisor(model);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await _service.MailService.SendVerifyOtp(model.Email);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);

            }
        }
        [HttpPost("RegisterStudent")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterRequestModel model)
        {
            try
            {
                var result = await

           _service.AuthenticationService.RegisterStudent(model);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await _service.MailService.SendVerifyOtp(model.Email);

                return StatusCode(201,"success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);

            }
        }
        [HttpPost("Login-2factor")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate2Factor([FromBody] LoginRequestModel model)
        {
            try
            {
                if (await _service.MailService.VerifyTwoFactorOtp(model.Email,model.AuCode))
                {
                    string outcome = await _service.AuthenticationService.ValidateUser(model);
                    var Tokendto = await _service.AuthenticationService.CreateToken(true);
                    return Ok(Tokendto);
                }
                return BadRequest("Wrong code");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        private async Task<IActionResult> LoginProcess(string outcome, bool twofactor, LoginRequestModel model)
        {
            try
            {
                if (outcome.Split("|")[0].Equals("BADLOGIN"))
                {
                    return Unauthorized("Wrong password or username");
                }
                if (outcome.Split("|")[0].Equals("UNVERIFIED"))
                {
                    return Ok("NeedVerify|" + outcome.Split("|")[1]);
                }
                if (outcome.Split("|")[0].Equals("UNVERIFIEDEMAIL"))
                {
                    return BadRequest("Email Need Verify|" + outcome.Split("|")[1]);
                }
                if (outcome.Split("|")[0].Equals("ISBANNED"))
                {
                    return Ok("Banned");
                }
                if (outcome.Split("|")[0].Equals("SUCCESS"))
                {
                    if (twofactor)
                    {
                        if (await _service.MailService.SendTwoFactorOtp(model.Email))
                        {
                            return Ok("Two factor code was sent to your email");
                        }
                        return BadRequest("Badrequest");
                    }
                    else
                    {
                        var Tokendto = await _service.AuthenticationService.CreateToken(true);
                        return Ok(Tokendto);
                    }
                }
                return NotFound("User not found");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpPost("Login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequestModel model)
        {
            string outcome = await _service.AuthenticationService.ValidateUser(model);
            var user = await _service.AccountService.GetUserByEmail(model.Email);
            return await LoginProcess(outcome, user.TwoFactorEnabled, model);
        }
        [HttpPost("Logout")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Logout([FromBody] TokenDTO model)
        {
            if (!await _service.AuthenticationService.InvalidateToken(model))
            {
                return Unauthorized("Invalid token");
            }
            return Ok("Logout Successfully");
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
            if(string.IsNullOrEmpty(model.VerifyCode) || string.IsNullOrEmpty(model.Email))
            {
                return BadRequest("empty verify code/ Email");
            }
            if(await _service.MailService.VerifyForgotPasswordOtp(model.Email,model.VerifyCode))
            {
                return Ok(model.Email);
            }
            return BadRequest("User not found or wrong verify code");
        }
    }
}
