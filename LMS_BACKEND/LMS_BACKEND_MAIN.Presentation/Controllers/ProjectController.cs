﻿using Entities.Exceptions;
using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using Shared.GlobalVariables;
using System.Security.Claims;
using System.Text.Json;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route(APIs.ProjectAPI)]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
    public class ProjectController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ProjectController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet(RoutesAPI.GetTaskListByProject)]
        public async Task<IActionResult> GetTaskListByProject(Guid projectId)
        {
            var hold = await _service.TaskListService.GetTaskListByProject(projectId);
            return Ok(hold);
        }

        [HttpGet(RoutesAPI.GetMemberInProject)]
        public async Task<IActionResult> GetMemberInProject(Guid projectId)
        {
            var hold = await _service.MemberService.GetMembers(projectId);
            return Ok(hold);
        }

        [HttpGet("{id:guid}")]
        [Authorize(Roles = Roles.SUPERVISOR)]
        public async Task<IActionResult> GetProject(Guid id)
        {
            var result = await _service.ProjectService.GetProjectById(id);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = Roles.SUPERVISOR)]
        public async Task<IActionResult> UpdateProject(Guid id, [FromBody] ProjectUpdateRequestModel model)
        {
            var current = await _service.AccountService.CheckUser(User);

            await (_service.ProjectService.UpdateProject(model, id, current));

            await (_service.NotificationService.CreateNotificationForProject(id, "Project Update", $"Project {model.Name} has been update", current));

            return Ok(new ResponseMessage { Message = "Update project successfuly" });
        }

        [HttpPost]
        [Authorize(Roles = Roles.SUPERVISOR)]
        public async Task<IActionResult> CreateProjejct(CreateProjectRequestModel model)
        {
            var current = await _service.AccountService.CheckUser(User);

            var result = await _service.ProjectService.CreateNewProject(current ,model);

            return CreatedAtAction(nameof(GetProject), new { id = result.Id }, result);
        }

        [HttpGet(RoutesAPI.GetJoinRequest)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear, Roles = Roles.SUPERVISOR)]
        public async Task<IActionResult> GetJoinRequest(Guid id)
        {
            return Ok(await _service.ProjectService.GetJoinRequest(id));
        }

        [HttpPost(RoutesAPI.ValidateJoinRequest)]
        [Authorize(Roles = Roles.SUPERVISOR)]
        public async Task<IActionResult> ValidateJoinRequest(Guid id, [FromBody] IEnumerable<UpdateStudentJoinRequestModel> modellist)
        {
            await _service.ProjectService.ValidateJoinRequest(modellist, id);
            return Ok(new ResponseMessage { Message = "Update success" });
        }

        [HttpGet(RoutesAPI.GetProjectResources)]
        public async Task<IActionResult> GetProjectResources(Guid projectId)
        {
            var hold = await _service.FileService.GetRootWithProjectId(projectId);

            return Ok(hold);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects([FromQuery] ProjectRequestParameters parameters)
        {
            var pageResult = await _service.ProjectService.GetAllProjects(parameters, trackChange: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pageResult.metaData));
            return Ok(pageResult.projects);
        }

        [HttpGet(RoutesAPI.GetProjects)]
        public async Task<IActionResult> GetProjects(string userId, [FromQuery] ProjectRequestParameters parameters)
        {
            var pageResult = await _service.ProjectService.GetProjects(userId, parameters, trackChange: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pageResult.metaData));
            return Ok(pageResult.projects);
        }

        [HttpPatch(RoutesAPI.MoveTaskListInProjectt)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        public async Task<IActionResult> MoveTaskListInProject(Guid projectId, Guid taskListId, [FromBody] JsonPatchDocument<TaskListUpdateRequestModel> patchDoc)
        {
            if (!patchDoc.Operations.Any()) throw new BadRequestException("patchDoc object sent from client is null.");

            var result = await _service.TaskListService.GetTaskListForPatch(projectId, taskListId);

            patchDoc.ApplyTo(result.taskListToPatch);

            var current = await _service.AccountService.CheckUser(User);

            await _service.TaskListService.SaveChangesForPatch(result.taskListToPatch, result.taskListEntity, current);

            return NoContent();
        }

    }
}
