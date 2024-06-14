using LMS_BACKEND_MAIN.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route("api/[Controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IServiceManager _service;
        public TokenController(IServiceManager service)
        {
            _service = service;
        }
        [HttpPost("refreshtoken")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Refresh([FromBody]TokenDTO model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var tokenDtoEnd = await _service.AuthenticationService.RefreshToken(model);
                    return Ok(tokenDtoEnd);
                }
                catch
                {
                    return StatusCode(500,"INTERNAL ERROR");
                }
            } 
            return BadRequest("Invalid Token");
        }
    }
}
