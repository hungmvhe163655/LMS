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

        //[HttpGet]
        ////[Authorize(AuthenticationSchemes = "Bearer")]
        //public async Task<IActionResult> GetNewsAsync([FromQuery] NewsRequestParameters newsParameters)
        //{
        //    var pageResult = await _service.NewsService.GetNewsAsync(newsParameters, trackChanges: false);

        //    Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pageResult.metaData));
        //    return Ok(pageResult.news);
        //}

        [HttpGet(RoutesAPI.GetProjectWithMember)]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetProjectWithMember(string userId)
        {
            var data = _service.ProjectService.GetProjects(userId);
            return Ok(data);
        }

        //[HttpGet()]
        ////[Authorize(AuthenticationSchemes = "Bearer")]
        //public async Task<IActionResult> GetProjectTaskList(string projectId)
        //{
        //    //var data = await _service.NewsService.GetNewsById(id);
        //    //return Ok(data);
        //}

        //[HttpPost]
        ////[Authorize(AuthenticationSchemes = "Bearer")]
        //public IActionResult CreateNews(CreateNewsRequestModel model)
        //{
        //    var data = _service.NewsService.CreateNewsAsync(model);
        //    return Ok(data);
        //}

        //[HttpPut("{newsid:guid}")]
        ////[Authorize(AuthenticationSchemes = "Bearer")]
        //public async Task<IActionResult> Update(Guid newsId, UpdateNewsRequestModel model)
        //{
        //    await _service.NewsService.UpdateNews(newsId, model);
        //    return Ok(new ResponseMessage { Message = "Update successfully" });
        //}


        //[HttpDelete("{newsid:guid}")]
        ////[Authorize(AuthenticationSchemes = "Bearer")]
        //public async Task<IActionResult> Delete(Guid newsId)
        //{
        //    await _service.NewsService.DeleteNews(newsId);
        //    return Ok(new ResponseMessage { Message = "Delete successfully" });
        //}

    }
}
