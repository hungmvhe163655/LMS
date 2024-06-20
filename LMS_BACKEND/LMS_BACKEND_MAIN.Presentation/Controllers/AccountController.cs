
using Contracts.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;

        public AccountController(IServiceManager service, ILoggerManager logger)
        {
            _logger = logger;
            _service = service;
        }
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
        [HttpPost("UpdateVerifierAccount")]
       // [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UpdateAccountVerifyStatus([FromBody]UpdateVerifyStatusRequestModel model)
        {
            if (model.UserID == null||model.verifierID==null)
            {
                ModelState.AddModelError("BadRequest", "Username can't be empty");
                return BadRequest();
            }
            try
            {
                var user = await _service.AccountService.GetUserById(model.UserID);
                if (user == null)
                {
                    return BadRequest(new ResponseObjectModel { Code = "401" ,Status = "BadRequest", Value = user});
                }
                var hold = new List<string>();
                hold.Add(model.UserID);
                if (await _service.AccountService.UpdateAccountVerifyStatus(hold,model.verifierID))
                {
                    return Ok(new ResponseObjectModel { Status = "success",Code = "200", Value = "Update User " + user.FullName + " Status Successully" });
                }
            }
            catch
            {
                
            }
            return BadRequest(ModelState);
        }
        [HttpPost("ChangePassword")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> ChangePassword(string userId, string oldPassword, string newPassword)
        {
            try
            {
                var user =
                await _service.AccountService.ChangePasswordAsync(userId,oldPassword, newPassword);
                return Ok(new { Status = "success", Value = user });
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost("UpdateProfile")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UpdateProfile(string userId, string name, string rollNumber, string major, string specialized)
        {
            try
            {
                var user =
                await _service.AccountService.UpdateProfileAsync(userId, name, rollNumber, major, specialized);
                return Ok(new { Status = "success", Value = user });
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
