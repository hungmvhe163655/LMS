using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contracts;
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
        private readonly ILogger _logger;
        public AccountController(IServiceManager service, ILogger logger)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet("GetVerifierAccount")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Get(string userName)
        {
            try
            {
                var user =
                _service.AccountService.GetVerifierAccounts(userName);
                return Ok(new { Status = "success", Value = user });
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost("UpdateVerifierAccount")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UpdateAccountVerifyStatus(string userName)
        {
            if (userName == null)
            {
                ModelState.AddModelError("BadRequest", "Username can't be empty");
                return BadRequest();
            }
            try
            {
                var user = await _service.AccountService.GetUserByName(userName);
                if (user == null)
                {
                    return BadRequest();
                }
                var hold = new List<string>();
                hold.Add(userName);
                if (await _service.AccountService.UpdateAccountVerifyStatus(hold))
                {
                    return Ok(new { Status = "success", Value = "Update User " + userName + " Status Successully" });
                }
            }
            catch
            {
                
            }
            return BadRequest(ModelState);
        }
    }
}
