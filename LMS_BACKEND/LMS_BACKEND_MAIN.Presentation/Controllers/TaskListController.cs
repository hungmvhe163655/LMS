using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route(APIs.TaskListAPI)]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly IServiceManager _service;

        public TaskListController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("{projectId}")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetTaskList(Guid projectId)
        {
            var hold = await _service.TaskListService.GetTaskList(projectId);
            return Ok(hold);
        }
        
    }
}
