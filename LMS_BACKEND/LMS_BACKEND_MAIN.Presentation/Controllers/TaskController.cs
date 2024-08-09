using Contracts.Interfaces;
using Entities.Exceptions;
using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using Shared.GlobalVariables;
using System.Security.Claims;
using System.Text.Json;

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
            var hold_user = await _service.AccountService.CheckUser(User);

            var hold = await _service.TaskService.CreateTask(model, hold_user);

            return CreatedAtAction(nameof(GetTaskById), new { id = hold.Id }, hold);
        }

        [HttpPut(RoutesAPI.AttachFileToTask)]
        public async Task<IActionResult> AttachFileToTask(Guid id, Guid fileid)
        {
            await _service.FileService.AttachToTask(id, fileid);

            return Ok(new ResponseMessage { Message = "Attach success" });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] TaskUpdateRequestModel model)
        {
            var current = await _service.AccountService.CheckUser(User);

            await _service.TaskService.EditTask(model, id, current);

            return Ok(new ResponseMessage { Message = "Update Task success" });
        }

        [HttpPut(RoutesAPI.AssignUserToTask)]
        public async Task<IActionResult> AssignUserToTask(Guid id, string userid)
        {
            var current = await _service.AccountService.CheckUser(User);

            await _service.TaskService.AssignUserToTask(id, userid, current);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var current = await _service.AccountService.CheckUser(User);

            await _service.TaskService.DeleteTask(id, current);

            return Ok(new ResponseMessage { Message = "Delete Success" });
        }

        [HttpGet("userId/{userId}")]
        public async Task<IActionResult> GetAllTaskByUser(string userId, [FromQuery] TaskRequestParameters parameters)
        {
            var pageResult = await _service.TaskService.GetTasksByUser(userId, parameters);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pageResult.metaData));

            return Ok(pageResult.tasks);
        }
        [HttpGet]
        [Route("{id:guid}/history")]
        public async Task<IActionResult> GetTaskHistoriesWithId(Guid Id, [FromQuery] TaskHistoryRequestParameters param)
        {
            var result = await _service.TaskService.GetTaskHistoriesWithTaskId(Id);

            var end = result.Skip(param.Cursor ?? SCROLL_LIST.DEFAULT_TOP).Take(param.Take ?? SCROLL_LIST.TINY10).ToList();

            var taken = end.Count + (param.Cursor ?? SCROLL_LIST.DEFAULT_TOP);

            return result.Count() > taken ? Ok(new { Data = end, Cursor = taken }) : Ok(new { Data = end });
        }
    }
}
