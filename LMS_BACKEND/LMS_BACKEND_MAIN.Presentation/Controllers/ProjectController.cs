using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

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
            return Ok(new ResponseMessage { Message = "Create project successfully" });
        }
        [HttpGet(RoutesAPI.GetJoinRequest)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear, Roles = Roles.SUPERVISOR)]
        public async Task<IActionResult> GetJoinRequest(Guid id)
        {
            return Ok(await _service.ProjectService.GetJoinRequest(id));
        }
        [HttpPost(RoutesAPI.ValidateJoinRequest)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear, Roles = Roles.SUPERVISOR)]
        public async Task<IActionResult> ValidateJoinRequest(Guid id,[FromBody] IEnumerable<UpdateStudentJoinRequestModel> modellist)
        {
            await _service.ProjectService.ValidateJoinRequest(modellist,id);
            return Ok(new ResponseMessage { Message = "Update success" });
        }
        [HttpGet(RoutesAPI.GetProjectResources)]
        public async Task<IActionResult> GetProjectResources(Guid projectId)
        {
            var hold = await _service.FileService.GetRootWithProjectId(projectId);

            return Ok(hold);
        }
    }
}
