using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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
    }
}
