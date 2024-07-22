using Entities.Exceptions;
using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System.Security.Claims;

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
            var result = await _service.TaskListService.CreateTaskList(model);
            return CreatedAtAction(nameof(GetTaskListById), new { id = result });
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

        private async Task<string> CheckUser()
        {
            var userClaims = User.Claims;

            var username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            var hold = await _service.AccountService.GetUserByName(username ?? throw new UnauthorizedException("lamao"));

            return hold.Id;
        }

        [HttpPatch(RoutesAPI.MoveTaskToTaskList)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        public async Task<IActionResult> MoveTaskToTaskList(Guid taskListId, Guid taskid, [FromBody] JsonPatchDocument<TaskUpdateRequestModel> patchDoc)
        {
            if (!patchDoc.Operations.Any()) throw new BadRequestException("patchDoc object sent from client is null.");

            var result = await _service.TaskService.MoveTaskForPatch(taskListId, taskid);

            var old_list = result.taskEntity.TaskListId;

            patchDoc.ApplyTo(result.taskToPatch);

            var new_list = await _service.TaskService.SaveChangesForPatch(result.taskToPatch, result.taskEntity, CheckUser().Result);

            return Ok(new ResponseMessage { Message = $"Move task {taskid} to task list from {old_list} to list {new_list} successfully " });
        }

    }
}
