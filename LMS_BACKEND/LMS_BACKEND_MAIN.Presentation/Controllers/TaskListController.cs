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

        [HttpGet("{taskListId}")]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        public async Task<IActionResult> GetTaskListById(Guid taskListId)
        {
            var hold = await _service.TaskListService.GetTaskListById(taskListId);
            return Ok(hold);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear, Roles = Roles.SUPERVISOR)]
        public async Task<IActionResult> CreateNewTaskList(CreateTaskListRequestModel model)
        {
            await _service.TaskListService.CreateTaskList(model);
            return Ok(new ResponseMessage { Message = "Create Task list successfully" });
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear, Roles = Roles.SUPERVISOR)]
        public async Task<IActionResult> UpdateTaskList(UpdateTaskListRequestModel model)
        {
            await _service.TaskListService.UpdateTaskList(model);
            return Ok(new ResponseMessage { Message = "Update task list successfully" });
        }

        [HttpDelete("{tasklistId}")]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear, Roles = Roles.SUPERVISOR)]
        public async Task<IActionResult> DeleteTaskList(Guid tasklistId)
        {
            await _service.TaskListService.DeleteTaskList(tasklistId);
            return Ok(new ResponseMessage { Message = "Delete task list successfully" });
        }

    }
}
