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
        [HttpGet(RoutesAPI.GetScheduleByDevice)]
        public async Task<IActionResult> GetScheduleByDevice(Guid id, [FromQuery] ScheduleRequestModel model)
        {
            return Ok(await _service.ScheduleService.GetScheduleForDevice(model, id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchedule([FromBody] ScheduleCreateRequestModel model)
        {
            var result = await _service.ScheduleService.CreateScheduleForDevice(model);

            return CreatedAtAction(nameof(GetScheduleWithId), new { id = result.Id }, result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetScheduleWithId(Guid id)
        {
            var hold = await _service.ScheduleService.GetSchedule(id);

            return Ok(hold);
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
