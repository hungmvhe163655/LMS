using LMS_BACKEND_MAIN.Presentation.Attributes;
using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route(APIs.TOKEN)]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServiceManager _service;
        public TokenController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost(RoutesAPI.TokenRefresh)]
        [ServiceFilter(typeof(DTOFilter))]
        public async Task<IActionResult> TokenRefresh([FromBody] TokenDTO model)
        {
            var tokenDtoEnd = await _service.AuthenticationService.RefreshTokens(model);
            return Ok(tokenDtoEnd);
        }
    }
}
