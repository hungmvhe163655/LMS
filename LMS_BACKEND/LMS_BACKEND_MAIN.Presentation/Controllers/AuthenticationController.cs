using LMS_BACKEND_MAIN.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared;
using Shared.DataTransferObjects.RequestDTO;
using System;
using System.Collections.Generic;
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
                await _service.MailService.SendVerifyOtp(model.UserName, model.Email);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest();

            }
        }
        [HttpPut("ReSendVerifyEmail")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ReSendVerifyEmail([FromBody] SimpleRequestModel model)
        {
            if(model.Propety1 == null)
            {
                return BadRequest();
            }
            if (await _service.MailService.SendVerifyOtp(model.Propety1, null))
            {
                return Ok("New Verify code Has been sent to your email");
            }
            return BadRequest();
        }
        [HttpPut("VerifyEmail")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> VerifyEmail([FromBody] SimpleRequestModel model)
        {
            var email = model.Propety1;
            var token = model.Propety2;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            {
                return BadRequest();
            }
            if(await _service.AuthenticationService.VerifyEmail(email, token))
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
                await _service.MailService.SendVerifyOtp(model.UserName, model.Email);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest();

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
                await _service.MailService.SendVerifyOtp(model.UserName, model.Email);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest();

            }
        }
        [HttpPost("Login-2factor")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate2Factor([FromBody] LoginRequestModel model)
        {
            try
            {
                if( await _service.MailService.VerifyTwoFactorOtp(model.UserName, model.AuCode)){
                    string outcome = await _service.AuthenticationService.ValidateUser(model);
                    var Tokendto = await _service.AuthenticationService.CreateToken(true);
                    return Ok(Tokendto);
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("Login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequestModel model)
        {
            string outcome = await _service.AuthenticationService.ValidateUser(model);
            var user = await _service.AccountService.GetUserByName(model.UserName);
            if (outcome.Split("|")[0].Equals("BADLOGIN"))
            {
                return Unauthorized("Wrong password or username");
            }
            if (outcome.Split("|")[0].Equals("UNVERIFIED"))
            {
                return Ok("NeedVerify" + outcome.Split("|")[1]);
            }
            if (outcome.Split("|")[0].Equals("ISBANNED"))
            {
                return Ok("Banned");
            }
            if (outcome.Split("|")[0].Equals("SUCCESS"))
            {
                if(user.TwoFactorEnabled)
                {
                    if(await _service.MailService.SendTwoFactorOtp(model.UserName, model.Email))
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
            return BadRequest();
        }
        [HttpPost("Logout")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Logout([FromBody] TokenDTO model)
        {
            if(!await _service.AuthenticationService.InvalidateToken(model))
            {
                return Unauthorized();
            }
            return Ok("Logout Successfully");
        }
    }
}
