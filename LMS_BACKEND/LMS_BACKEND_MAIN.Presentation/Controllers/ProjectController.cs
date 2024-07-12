using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route(APIs.ProjectAPI)]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ProjectController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet(RoutesAPI.GetTaskListByProject)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        public async Task<IActionResult> GetTaskListByProject(Guid projectId)
        {
            var hold = await _service.TaskListService.GetTaskListByProject(projectId);
            return Ok(hold);
        }

        [HttpGet(RoutesAPI.GetMemberInProject)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        public async Task<IActionResult> GetMemberInProject(Guid projectId)
        {
            var hold = await _service.MemberService.GetMembers(projectId);
            return Ok(hold);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear, Roles = Roles.SUPERVISOR)]
        public async Task<IActionResult> CreateProjejct(CreateProjectRequestModel model)
        {
            await _service.ProjectService.CreatNewProject(model);
            return Ok(new ResponseMessage { Message = "Create project successfully"});
        }

    }
}
