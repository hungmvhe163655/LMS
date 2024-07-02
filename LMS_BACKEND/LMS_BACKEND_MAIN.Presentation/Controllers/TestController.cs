
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IServiceManager _service;

        public TestController(IServiceManager service)
        {
            _service = service;
        }
        [HttpPost("Notifi")]
        public async Task<IActionResult> CreateNotifyTest([FromBody] CreateNotificationRequestModel model)
        {
            var hold = await _service.NotificationService.CreateNotification(model.Title, model.Content, model.Type, model.CreateUserId, "lmao");
            return Ok(hold);
        }
    }
}
