using Entities.Exceptions;
using LMS_BACKEND_MAIN.Presentation.Attributes;
using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using System.Text.Json;

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
        //[Authorize(AuthenticationSchemes = AuthorizeScheme.Bear, Roles = Roles.SUPERVISOR)]
        [HttpGet(RoutesAPI.GetAccountNeedVerified)]
        public async Task<IActionResult> GetAccountNeedVerified([FromQuery] NeedVerifyParameters param)
        {
            var user = await
            _service.AccountService.GetVerifierAccounts(param);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(user.meta));

            return Ok(user.data);
        }

        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear, Roles = Roles.SUPERVISOR)]
        [HttpPost(RoutesAPI.UpdateAccountVerifyStatus)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateAccountVerifyStatus([FromBody] UpdateVerifyStatusRequestModel model)
        {
            var user = await _service.AccountService.GetUserById(model.verifierID)?? throw new BadRequestException("User with that id is not found");

            await _service.AccountService.UpdateAccountVerifyStatus(model.UserID, model.verifierID);

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
