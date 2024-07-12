using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [ApiController]
    [Route(APIs.ScheduleAPI)]
    public class ScheduleController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ScheduleController(IServiceManager service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetScheduleByDevice([FromBody] ScheduleRequestModel model)
        {
            return Ok(await _service.ScheduleService.GetScheduleForDevice(model));
        }
        [HttpPost]
        public async Task<IActionResult> CreateSchedule([FromBody] ScheduleCreateRequestModel model)
        {
            await _service.ScheduleService.CreateScheduleForDevice(model);

            return Ok(model);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteSchedule(Guid id)
        {
            await _service.ScheduleService.DeleteSchedule(id);

            return Ok();
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateSchedule(Guid id, [FromBody] ScheduleUpdateRequestModel model)
        {
            await _service.ScheduleService.UpdateSchedule(id, model);

            return Ok();
        }
    }
}
