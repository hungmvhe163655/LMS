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

        [HttpGet(RoutesAPI.GetProjectWithMember)]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
        public IActionResult GetProjectWithMember(string userId)
        {
            var data = _service.ProjectService.GetProjects(userId);
            return Ok(data);
        }

        [HttpPost("{userId}")]
        [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear, Roles = Roles.SUPERVISOR)]
        public async Task<IActionResult> CreateProjejct(string userId, CreateProjectRequestModel model)
        {
            await _service.ProjectService.CreatNewProject(userId, model);
            return Ok(new ResponseMessage { Message = "Create project successfully"});
        }

    }
}
