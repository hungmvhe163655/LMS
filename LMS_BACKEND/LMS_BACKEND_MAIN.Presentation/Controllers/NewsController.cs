using Entities.Exceptions;
using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using System.Security.Claims;
using System.Text.Json;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route(APIs.NewsAPI)]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
    public class NewsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public NewsController(IServiceManager service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetNewsAsync([FromQuery] NewsRequestParameters newsParameters)
        {
            var pageResult = await _service.NewsService.GetNewsAsync(newsParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pageResult.metaData));
            return Ok(pageResult.news);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetNewsById(Guid id)
        {
            var data = await _service.NewsService.GetNewsById(id);
            return Ok(data);
        }

        [HttpPost]
        [Authorize(Roles = Roles.SUPERVISOR)]
        public async Task<IActionResult> CreateNews(CreateNewsRequestModel model)
        {
            var current = await _service.AccountService.CheckUser(User);

            var result = await _service.NewsService.CreateNewsAsync( current, model);

            return CreatedAtAction(nameof(GetNewsById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = Roles.SUPERVISOR)]
        public async Task<IActionResult> Update(Guid id, UpdateNewsRequestModel model)
        {
            await _service.NewsService.UpdateNews(id, model);
            return Ok(new ResponseMessage { Message = "Update successfully" });
        }


        [HttpDelete("{id:guid}")]
        [Authorize(Roles = Roles.SUPERVISOR)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.NewsService.DeleteNews(id);
            return NoContent();
        }

    }
}
