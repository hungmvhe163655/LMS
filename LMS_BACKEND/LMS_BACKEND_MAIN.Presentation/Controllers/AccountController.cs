using LMS_BACKEND_MAIN.Presentation.Attributes;
using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route(APIs.AccountAPI)]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AccountController(IServiceManager service)
        {
            _service = service;
        }
        /*
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear, Roles = Roles.ADMIN)]
        [HttpPost(RoutesAPI.CreateAdmin)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateAdmin([FromBody] RegisterRequestModel model)
        {
            var result = await _service.AuthenticationService.RegisterLabLead(model);

            return StatusCode(201, result);
        }
        */
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear, Roles = Roles.ADMIN)]
        [HttpGet(RoutesAPI.GetAccountNeedVerified)]
        public IActionResult GetAccountNeedVerified(string email)
        {
            var user =
            _service.AccountService.GetVerifierAccounts(email);
            return Ok(user);
        }

        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear, Roles = Roles.SUPERVISOR)]
        [HttpPost(RoutesAPI.UpdateAccountVerifyStatus)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateAccountVerifyStatus([FromBody] UpdateVerifyStatusRequestModel model)
        {

            var user = await _service.AccountService.GetUserById(model.UserID);

            if (user == null)
            {
                return NotFound(new ResponseMessage { Message = "User Not Found" });
            }

            var hold = new List<string> { model.UserID };
            await _service.AccountService.UpdateAccountVerifyStatus(hold, model.verifierID);
            return Ok(new ResponseMessage { Message = "Update User " + user.FullName + " Status Successully" });
        }
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> GetAccountDetail(string id)
        {
            var data = await _service.AccountService.GetAccountDetail(id);
            return Ok(data);
        }
    }
}
