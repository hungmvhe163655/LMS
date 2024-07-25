using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System.IO;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route(APIs.FileAPI)]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public FileController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpPost(RoutesAPI.UploadFile)]
        public async Task<IActionResult> UploadFile(Guid folderid, [FromForm] IFormFile file)
        {
            if (file.Length == 0)
            {
                return BadRequest(new ResponseMessage { Message = "File Is Null Or Empty" });
            }
            var metadata = new FileUploadRequestModel { FolderId = folderid, MimeType = file.ContentType, Size = file.Length, Name = file.Name };

            if (metadata == null)
            {
                return BadRequest(new ResponseMessage { Message = "Metadata is required" });
            }

            using var memoryStream = new MemoryStream();

            await file.CopyToAsync(memoryStream);

            memoryStream.Position = 0;

            var result = await _serviceManager.FileService.CreateFile(metadata, memoryStream);

            return CreatedAtAction(nameof(DownloadFile), new { id = result.Id }, result);

        }

        [HttpGet]
        [Route(RoutesAPI.DownloadFile)]
        public async Task<IActionResult> DownloadFile(Guid id)
        {

            var (fileStream, fileDetail) = await _serviceManager.FileService.GetFile(id);

            if (fileStream == null || fileDetail == null)
            {
                return NotFound(new { Code = 404, Status = "Failed", Value = "File not found" });
            }

            var fileDetailJson = JsonConvert.SerializeObject(new { Code = 200, Status = "Success", Value = fileDetail });

            Response.Headers.Add("X-File-Details", fileDetailJson);

            return File(fileStream, fileDetail.MimeType, fileDetail.Name);

        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteFile(Guid id)
        {
            await _serviceManager.FileService.DeleteFile(id);

            return Ok(new ResponseMessage { Message = "DELETEFILE" });
        }
        [HttpPost(RoutesAPI.UploadImage)]
        public async Task<IActionResult> UploadImage(string type,[FromForm] IFormFile file)
        {
            using var memoryStream = new MemoryStream();

            await file.CopyToAsync(memoryStream);

            memoryStream.Position = 0;

            return Ok(await _serviceManager.FileService.UploadFile(memoryStream, file.ContentType, type));
        }
        [HttpGet(RoutesAPI.DownloadImage)]
        public async Task<IActionResult> DownloadImage(string key)
        {
            var hold = await _serviceManager.FileService.DownloadFile(key);

            return File(hold, "image/png");
        }
        [HttpDelete(RoutesAPI.DeleteImage)]
        public async Task<IActionResult> DeleteImage(string key)
        {
            await _serviceManager.FileService.RemoveFile(key);

            return Ok(new ResponseMessage { Message = "Remove Success" });
        }

    }
}
