
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;

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
