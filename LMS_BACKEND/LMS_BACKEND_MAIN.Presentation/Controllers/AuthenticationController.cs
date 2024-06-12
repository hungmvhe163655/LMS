using LMS_BACKEND_MAIN.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route("api/authen")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController(IServiceManager serviceManager)
        {
            _service = serviceManager;
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] StudentRegisterRequestModel model)
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
            return StatusCode(201);
        }
        public async Task<IActionResult> Authenticate([FromBody] LoginRequestModel model)
        {
            if(!await _service.AuthenticationService.ValidateUser(model))
            {
                return Unauthorized();
            }
            var Tokendto = await _service.AuthenticationService.CreateToken(true);
            return Ok(Tokendto);
        }
        public async Task<IActionResult> Logout()
        {
            if(!await _service.AuthenticationService.InvalidateToken())
            {
                return Unauthorized();
            }
            return Ok("Logout Successfully");
        }
    }
}
