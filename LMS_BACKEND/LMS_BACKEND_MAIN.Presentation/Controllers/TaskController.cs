using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
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
    [ApiController]
    [Route(APIs.TaskAPI)]
    //[Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
    public class TaskController : ControllerBase
    {
        private readonly IServiceManager _service;
        public TaskController(IServiceManager serviceManager)
        {
            _service = serviceManager;
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            return Ok(await _service.TaskService.GetTaskByID(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskCreateRequestModel model)
        {
            await _service.TaskService.CreateTask(model);

            return Ok(new ResponseMessage { Message = "Create Task success" });
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody] TaskUpdateRequestModel model)
        {
            await _service.TaskService.EditTask(model);

            return Ok(new ResponseMessage { Message = "Update Task success" });
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            await _service.TaskService.DeleteTask(id);

            return Ok(new ResponseMessage { Message = "Delete Success" });
        }
    }
}
