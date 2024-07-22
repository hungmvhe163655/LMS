using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [ApiController]
    [Route(APIs.NotificationAPI)]
    public class NotificationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public NotificationController(IServiceManager service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]NotificationParameters param)
        {
            var hold = await _service.NotificationService.GetPagedNotifications(param);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(hold.MetaData));

            return Ok(hold);
        }

        [HttpGet(RoutesAPI.GetById)]
        public async Task<IActionResult> GetById(Guid id, string userid)
        {
            await _service.NotificationService.MarkNotificationAsRead(userid, id);

            return Ok(await _service.NotificationService.GetNotification(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateNotificationRequestModel model)
        {
            var hold = await _service.NotificationService.CreateNotification(model);

            return CreatedAtAction(nameof(GetById), new { id = hold.Id }, hold);
        }

        /*
        [HttpPut(RoutesAPI.MarkNotificationAsRead)]
        public async Task<IActionResult> MarkNotificationAsRead(Guid id, string userid)
        {
            await _service.NotificationService.MarkNotificationAsRead(userid, id);
            return Ok(new ResponseMessage { Message = "Success" });
        }
        */
    }
}
