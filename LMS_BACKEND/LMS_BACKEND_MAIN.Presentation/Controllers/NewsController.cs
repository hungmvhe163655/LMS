using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public NewsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetNewsAsync([FromQuery] NewsRequestParameters newsParameters)
        {
            var news = await _service.NewsService.GetNewsAsync(newsParameters, trackChanges: false);

            return Ok(new { Status = "success", Value = news });
        }

        [HttpGet("{id}")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetNewsById(Guid id)
        {
                var data = await _service.NewsService.GetNewsById(id);
                return Ok(new { Status = "success", Value = data });
        }

        [HttpPost]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult CreateNews(CreateNewsRequestModel model)
        {
                var data = _service.NewsService.CreateNewsAsync(model);
                return Ok(new { Status = "success", Value = data });
        }

        [HttpPut("{newsid:guid}")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Update(Guid newsId, UpdateNewsRequestModel model)
        {
                var data = _service.NewsService.UpdateNewsAsync(newsId, model);
                return Ok(new { Status = "success", Value = data });
        }


        [HttpDelete("{id:guid}")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Delete(Guid id)
        {
                var data = _service.NewsService.DeleteNewsAsync(id);
                return Ok(new { Status = "success", Value = data });
        }

    }
}
