using Entities.Exceptions;
using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route(APIs.DeviceAPI)]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
    public class DeviceController : ControllerBase
    {
        private readonly IServiceManager _service;

        public DeviceController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetDevices([FromQuery] DeviceRequestParameters parameters)
        {
            var result = await _service.DeviceService.GetDevice(parameters);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.meta));
            return Ok(result.data);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetDevicesById(Guid id)
        {
            var result = await _service.DeviceService.GetDeviceById(id);
            return Ok(result);
        }

        private async Task<string> CheckUser()
        {
            var userClaims = User.Claims;

            var username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            var hold = await _service.AccountService.GetUserByName(username ?? throw new UnauthorizedException("lamao"));

            return hold.Id;
        }

        [HttpPost]
        [Authorize(Roles = Roles.SUPERVISOR)]
        public async Task<IActionResult> CreateDevice(CreateDeviceRequestModel model)
        {
            var result = await _service.DeviceService.CreateNewDevice(CheckUser().Result, model);
            return CreatedAtAction(nameof(GetDevicesById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateDevice(Guid id, UpdateDeviceRequestModel model)
        {
            await _service.DeviceService.UpdateDevice(id, model);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteDevice(Guid id)
        {
            await _service.DeviceService.DeleteDevice(id);
            return NoContent();
        }
    }
}
