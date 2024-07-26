﻿using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route(APIs.FolderAPI)]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthorizeScheme.Bear)]
    public class FolderController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public FolderController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetFolder(Guid id)
        {
            return Ok(await _serviceManager.FileService.GetFolderContent(id));
        }

        [HttpGet(RoutesAPI.GetProjectFolderScheme)]
        public async Task<IActionResult> GetProjectFolderScheme(Guid id)
        {
            return Ok(await _serviceManager.FileService.GetRootWithProjectId(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateFolder(CreateFolderRequestModel model)
        {
            var result = await _serviceManager.FileService.CreateFolder(model);

            if (result == null)
            {
                return BadRequest(new ResponseMessage { Message = "Failed Create Folder" });
            }
            return CreatedAtAction(nameof(GetFolder),new {id = result.Id}, result);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteFolder(Guid id)
        {
            await _serviceManager.FileService.DeleteFolder(id);

            return Ok(new ResponseMessage { Message = "DELETEFILE" });
        }

    }
}
