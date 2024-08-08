using Entities.Exceptions;
using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [ApiController]
    [Route(APIs.CommentAPI)]
    [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
    public class CommentController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CommentController(IServiceManager serviceManager)
        {
            _service = serviceManager;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCommentById(Guid id)
        {
            return Ok(await _service.CommentService.GetCommentById(id));
        }

        [HttpGet(RoutesAPI.GetCommentByTaskId)]
        public async Task<IActionResult> GetCommentByTaskId(Guid taskid, [FromQuery] CommentParameters param)
        {
            var hold = await _service.CommentService.GetPagedComment(taskid, param);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(hold.MetaData));

            return Ok(hold.ToList());
        }

        [HttpPost(RoutesAPI.CreateComment)]
        public async Task<IActionResult> CreateComment(Guid taskid, [FromBody] CreateCommentRequestModel model)
        {
            var current = await _service.AccountService.CheckUser(User);

            var hold = await _service.CommentService.CreateComment(model, current, taskid);

            return CreatedAtAction(nameof(GetCommentById), new { id = hold.Id }, hold);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            await _service.CommentService.UpdateComment(new UpdateCommentRequestModel { Content = "Comment has been deleted by user" }, id);

            return Ok(new ResponseMessage { Message = "Delete Success" });
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateComment(Guid id, [FromBody] UpdateCommentRequestModel model)
        {
            await _service.CommentService.UpdateComment(model, id);

            return Ok(new ResponseMessage { Message = "Update success" });
        }
    }
}
