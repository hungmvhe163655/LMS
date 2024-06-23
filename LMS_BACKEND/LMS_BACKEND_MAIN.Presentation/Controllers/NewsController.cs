using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public NewsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("Gets")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Gets(NewsRequestGetListsModel newsRequestGetLists)
        {
            try
            {
                var data = _service.NewsService.GetNews(newsRequestGetLists);
                return Ok(new { Status = "success", Value = data });
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetDetails")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetDetails(int id)
        {
            try
            {
                var data = _service.NewsService.GetNewsDetail(id);
                return Ok(new { Status = "success", Value = data });
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("Create")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Create(NewsRequestCreateModel newsRequestCreateModel)
        {
            try
            {
                var data = _service.NewsService.CreateNews(newsRequestCreateModel);
                return Ok(new { Status = "success", Value = data });
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("Update")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Update(NewsRequestUpdateModel newsRequestUpdateModel)
        {
            try
            {
                var data = _service.NewsService.UpdateNews(newsRequestUpdateModel);
                return Ok(new { Status = "success", Value = data });
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("Delete")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = _service.NewsService.DeleteNews(id);
                return Ok(new { Status = "success", Value = data });
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
