
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AccountController(IServiceManager service)
        {
            _service = service;
        }
        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUsers(string role)
        {
            try
            {
                var hold = await _service.AccountService.GetUserByRole(role.ToUpper());
                if (hold != null)
                {
                    return StatusCode(200, new ResponseObjectModel { Code = "200", Status = "OK", Value = hold.Where(x => x.IsVerified = true) });
                }
                return StatusCode(200, new ResponseObjectModel { Code = "200", Status = "EMPTY", Value = hold });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = "500", Status = "Internal Error", Value = ex });
            }

        }
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Supervisor")]
        [HttpGet("GetVerifierAccount")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Get(string email)
        {
            try
            {
                var user =
                _service.AccountService.GetVerifierAccounts(email);
                return Ok(new { Status = "success", Value = user });
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Supervisor")]
        [HttpPost("UpdateVerifierAccount")]
        // [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "labadmin")]
        public async Task<IActionResult> UpdateAccountVerifyStatus([FromBody] UpdateVerifyStatusRequestModel model)
        {
            if (model.UserID == null || model.verifierID == null)
            {
                ModelState.AddModelError("BadRequest", "Username can't be empty");
                return BadRequest();
            }
            try
            {
                var user = await _service.AccountService.GetUserById(model.UserID);
                if (user == null)
                {
                    return BadRequest(new ResponseObjectModel { Code = "401", Status = "BadRequest", Value = user });
                }
                var hold = new List<string>
                {
                    model.UserID
                };
                if (await _service.AccountService.UpdateAccountVerifyStatus(hold, model.verifierID))
                {
                    return Ok(new ResponseObjectModel { Status = "success", Code = "200", Value = "Update User " + user.FullName + " Status Successully" });
                }
            }
            catch
            {

            }
            return BadRequest(ModelState);
        }

        [HttpPost("ChangePassword")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestModel model)
        {
            if (model.UserID == null || model.OldPassword == null || model.NewPassword == null)
            {
                ModelState.AddModelError("BadRequest", "Username can't be empty");
                return BadRequest();
            }
            try
            {
                if (await _service.AccountService.ChangePasswordAsync(model.UserID, model.OldPassword, model.NewPassword))
                {
                    return Ok(new ResponseObjectModel { Status = "success", Code = "200", Value = "Change Password Successully" });
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
            return BadRequest();
        }
        [HttpPost("UpdateProfile")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequestModel model)
        {
            if (model.UserID == null || model.FullName == null || model.RollNumber == null || model.Major == null || model.Specialized == null)
            {
                ModelState.AddModelError("BadRequest", "Username can't be empty");
                return BadRequest();
            }
            try
            {
                if (await _service.AccountService.UpdateProfileAsync(model.UserID, model.FullName, model.RollNumber, model.Major, model.Specialized))
                    return Ok(new ResponseObjectModel { Status = "success", Code = "200", Value = "Update Profile Successully" });
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
            return BadRequest();
        }
    }
}
