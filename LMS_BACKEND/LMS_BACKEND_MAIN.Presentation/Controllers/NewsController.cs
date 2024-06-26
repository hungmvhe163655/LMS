using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

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

        [HttpPost("Gets")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Gets([FromBody] NewsRequestGetListsModel newsRequestGetLists)
        {
            try
            {
                var data = await _service.NewsService.GetNews(newsRequestGetLists);
                if (data != null)
                {
                    return StatusCode(200, new ResponseObjectModel { Code = "200", Status = "OK", Value = data });
                }
                return StatusCode(200, new ResponseObjectModel { Code = "200", Status = "EMPTY", Value = data });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = "500", Status = "Internal Error", Value = ex });
            }
        }

        [HttpPost("GetDetails")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetDetails(int id)
        {
            try
            {
                var data = await _service.NewsService.GetNewsDetail(id);

                if (data != null)
                {
                    return StatusCode(200, new ResponseObjectModel { Code = "200", Status = "OK", Value = data });
                }
                return StatusCode(200, new ResponseObjectModel { Code = "200", Status = "EMPTY", Value = data });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = "500", Status = "Internal Error", Value = ex });
            }
        }

        [HttpPost("Create")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Create([FromBody] NewsRequestCreateModel newsRequestCreateModel)
        {
            try
            {
                var data = await _service.NewsService.CreateNews(newsRequestCreateModel);
                if (data != null && data == true)
                {
                    return StatusCode(200, new ResponseObjectModel { Status = "success", Code = "200", Value = "Create News Status Successully" });
                }
                return StatusCode(200, new ResponseObjectModel { Code = "401", Status = "Internal Error Create" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = "500", Status = "Internal Error", Value = ex });
            }
        }

        [HttpPut("Update")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Update([FromBody] NewsRequestUpdateModel newsRequestUpdateModel)
        {
            try
            {
                var data = await _service.NewsService.UpdateNews(newsRequestUpdateModel);
                if (data != null && data == true)
                {
                    return StatusCode(200, new ResponseObjectModel { Status = "success", Code = "200", Value = "Update News Status Successully" });
                }
                return StatusCode(200, new ResponseObjectModel { Code = "401", Status = "Internal Error Create" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = "500", Status = "Internal Error", Value = ex });
            }
        }


        [HttpDelete("Delete")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _service.NewsService.DeleteNews(id);
                if (data != null && data == true)
                {
                    return StatusCode(200, new ResponseObjectModel { Status = "success", Code = "200", Value = "Delete News Status Successully" });
                }
                return StatusCode(200, new ResponseObjectModel { Code = "200", Status = "Internal Error Create" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = "500", Status = "Internal Error", Value = ex });
            }
        }

    }
}
