﻿using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route(APIs.TaskListAPI)]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly IServiceManager _service;

        public TaskListController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("{projectId}")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetTaskList(Guid projectId)
        {
            var hold = await _service.TaskListService.GetTaskList(projectId);
            return Ok(hold);
        }

        //[HttpGet]
        ////[Authorize(AuthenticationSchemes = "Bearer")]
        //public async Task<IActionResult> GetNewsAsync([FromQuery] NewsRequestParameters newsParameters)
        //{
        //    var pageResult = await _service.NewsService.GetNewsAsync(newsParameters, trackChanges: false);

        //    Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pageResult.metaData));
        //    return Ok(pageResult.news);
        //}

        //[HttpGet("{id}")]
        ////[Authorize(AuthenticationSchemes = "Bearer")]
        //public async Task<IActionResult> GetNewsById(Guid id)
        //{
        //    var data = await _service.NewsService.GetNewsById(id);
        //    return Ok(data);
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