using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;

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

        //[HttpGet("news")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        //public IActionResult Gets(string? title)
        //{
        //    try
        //    {
        //        var data = _service.NewsService.GetNewsByTitle(title);
        //        return Ok(new { Status = "success", Value = data });
        //    }
        //    catch
        //    {
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetNewsById(string id)
        {
                var data = _service.NewsService.GetNewsById(id);
                return Ok(new { Status = "success", Value = data });
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult CreateNews(NewsRequestModel model)
        {
                var data = _service.NewsService.CreateNewsAsync(model);
                return Ok(new { Status = "success", Value = data });
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Update(NewsRequestModel model)
        {
                var data = _service.NewsService.UpdateNewsAsync(model);
                return Ok(new { Status = "success", Value = data });
        }


        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Delete(int id)
        {
                var data = _service.NewsService.DeleteNewsAsync(id);
                return Ok(new { Status = "success", Value = data });
        }

    }
}
