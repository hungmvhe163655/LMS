using Entities.Exceptions;
using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [ApiController]
    [Route(APIs.TaskAPI)]
    [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
    public class TaskController : ControllerBase
    {
        private readonly IServiceManager _service;
        public TaskController(IServiceManager serviceManager)
        {
            _service = serviceManager;
        }

        [HttpGet(RoutesAPI.GetTaskByProjectId)]
        public async Task<IActionResult> GetTaskByProjectId(Guid id)
        {
            return Ok(await _service.TaskService.GetTasksWithProjectId(id));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            return Ok(await _service.TaskService.GetTaskByID(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskCreateRequestModel model)
        {
            if (!(await CheckUser()).Equals(model.CreatedBy)) throw new UnauthorizedException("You don't have access to this fuction");

            await _service.TaskService.CreateTask(model);

            return Ok(new ResponseMessage { Message = "Create Task success" });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody] TaskUpdateRequestModel model)
        {
            if (!(await CheckUser()).Equals(model.CreatedBy)) throw new UnauthorizedException("You don't have access to this fuction");

            await _service.TaskService.EditTask(model);

            return Ok(new ResponseMessage { Message = "Update Task success" });
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            await _service.TaskService.DeleteTask(id, CheckUser().Result);

            return Ok(new ResponseMessage { Message = "Delete Success" });
        }

        private async Task<string> CheckUser()
        {
            var userClaims = User.Claims;

            var username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            var hold = await _service.AccountService.GetUserByName(username ?? throw new UnauthorizedException("lamao"));

            return hold.Id;
        }
    }
}
