using Entities.Exceptions;
using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using System.Security.Claims;

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
            var result = await _serviceManager.FileService.GetFolderWithId(id);

            return Ok(result);
        }

        [HttpGet]
        [Route(RoutesAPI.DownloadFolder)]
        public async Task<IActionResult> DownloadFolder(Guid id)
        {
            var fileStream = await _serviceManager.FileService.DownloadFolder(id);

            return File(fileStream.Data, "application/zip", fileStream.FileName + ".zip");
        }

        [HttpGet(RoutesAPI.GetFolderFolders)]
        public async Task<IActionResult> GetFolderFolders([FromQuery] FolderRequestParameters param, Guid id)
        {
            var (Data, Cursor) = await _serviceManager.FileService.GetFolderFolders(param, id);

            return Cursor != null ? Ok(new { Data, Cursor }) : Ok(new { Data });
        }

        [HttpGet(RoutesAPI.GetFolderFiles)]
        public async Task<IActionResult> GetFolderFiles([FromQuery] FilesRequestParameters param, Guid id)
        {
            var (Data, Cursor) = await _serviceManager.FileService.GetFolderFiles(param, id);

            return Cursor != null ? Ok(new { Data, Cursor }) : Ok(new { Data });
        }

        [HttpGet(RoutesAPI.GetFolderContent)]
        public async Task<IActionResult> GetFolderContent([FromQuery] FolderRequestParameters param, Guid id)
        {
            var (Data, Cursor) = await _serviceManager.FileService.GetFolderContent(param, id);

            return Cursor != null ? Ok(new { Data, Cursor }) : Ok(new { Data });
        }

        [HttpGet(RoutesAPI.GetProjectFolderScheme)]
        public async Task<IActionResult> GetProjectFolderScheme(Guid id)
        {
            return Ok(await _serviceManager.FileService.GetRootWithProjectId(id));
        }

        [HttpPost("{id:guid}")]
        public async Task<IActionResult> CreateFolder(Guid id, CreateFolderRequestModel model)
        {
            var current = await _serviceManager.AccountService.CheckUser(User);

            var result = await _serviceManager.FileService.CreateFolder(model, current, id);

            if (result == null)
            {
                return BadRequest(new ResponseMessage { Message = "Failed Create Folder" });
            }
            return CreatedAtAction(nameof(GetFolder), new { id = result.Id }, result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteFolder(Guid id)
        {
            await _serviceManager.FileService.DeleteFolder(id);

            return Ok(new ResponseMessage { Message = "DELETEFILE" });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateFoldername(Guid id, [FromBody] FolderEditRequestModel model)
        {
            await _serviceManager.FileService.EditFolder(id, model);

            return Ok(new ResponseMessage { Message = "Update Successfully" });
        }
    }
}
