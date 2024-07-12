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
    [Route(APIs.NewsAPI)]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public NewsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetNewsAsync([FromQuery] NewsRequestParameters newsParameters)
        {
            var pageResult = await _service.NewsService.GetNewsAsync(newsParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pageResult.metaData));
            return Ok(pageResult.news);
        }

        [HttpGet("{id:guid}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetNewsById(Guid id)
        {
                var data = await _service.NewsService.GetNewsById(id);
                return Ok(data);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult CreateNews(CreateNewsRequestModel model)
        {
                var data = _service.NewsService.CreateNewsAsync(model);
                return Ok(data);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Update(UpdateNewsRequestModel model)
        {
                await _service.NewsService.UpdateNews(model);
                return Ok(new ResponseMessage { Message = "Update successfully" });
        }


        [HttpDelete("{id:guid}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Delete(Guid id)
        {
                await _service.NewsService.DeleteNews(id);
                return Ok(new ResponseMessage { Message = "Delete successfully" });
        }

    }
}
