using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async Task<IActionResult> GetAllByDeviceId(Guid id)
        {
            return Ok();
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetReportById(Guid id)
        {
            return Ok();
        }
    }
}
