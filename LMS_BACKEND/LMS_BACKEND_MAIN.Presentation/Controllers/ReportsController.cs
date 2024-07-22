using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    [Route(APIs.ReportAPI)]
    [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
    public class ReportsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ReportsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet(RoutesAPI.GetAllByDeviceId)]
        public async Task<IActionResult> GetAllByDeviceId(Guid id, [FromQuery] ReportRequestParameters param)
        {
            var result = await _service.ReportService.GetallReportsWithParam(id, param);

            Response.Headers.Add("X-Pagimation", JsonSerializer.Serialize(result.meta));

            return Ok(result.data);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetReportById(Guid id)
        {
            return Ok(await _service.ReportService.GetReport(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] CreateReportRequestModel model)
        {
            var hold = await _service.ReportService.CreateReport(model);

            return CreatedAtAction(nameof(GetReportById), new { id = hold });
        }
        [HttpPut]
        public async Task<IActionResult> UpdateReport(Guid Id, [FromBody] UpdateReportRequestModel model)
        {
            await _service.ReportService.UpdateReport(Id, model);

            return Ok(new ResponseMessage { Message = "Update success" });
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteReport(Guid Id)
        {
            await _service.ReportService.DeleteReport(Id);

            return Ok(new ResponseMessage { Message = "Delete success" });
        }
    }
}
