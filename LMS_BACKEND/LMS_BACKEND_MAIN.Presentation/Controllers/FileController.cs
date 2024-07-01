using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public FileController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpPost("upload/{folderid:guid}")]
        public async Task<IActionResult> UploadFile(Guid folderid, [FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new ResponseObjectModel { Code = 400, Status = "Failed", Value = "FILE IS NULL OR EMPTY" });
            }
            var metadata = new FileUploadRequestModel { FolderId = folderid, MimeType = file.ContentType, Size = file.Length, Name = file.Name };

            if (metadata == null)
            {
                return BadRequest(new ResponseObjectModel { Code = 400, Status = "Failed", Value = "Metadata is required" });
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);

                memoryStream.Position = 0;

                await _serviceManager.FileService.CreateFile(metadata, memoryStream);

                return Ok(new ResponseObjectModel { Code = 200, Status = "Success", Value = "File uploaded successfully." });
            }
        }
        [HttpGet]
        [Route("download/{id:guid}")]
        public async Task<IActionResult> DownloadFile(Guid id)
        {
            try
            {
                var (fileStream, fileDetail) = await _serviceManager.FileService.GetFile(id);

                if (fileStream == null || fileDetail == null)
                {
                    return NotFound(new { Code = 404, Status = "Failed", Value = "File not found" });
                }

                var fileDetailJson = JsonConvert.SerializeObject(new { Code = 200, Status = "Success", Value = fileDetail });

                //Response.Headers.Add("X-File-Details", fileDetailJson);
                return File(fileStream, fileDetail.MimeType, fileDetail.Name);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectModel { Code = 500, Status = "Failed", Value = $"An error occurred while Dowloading the file.{ex.Message}" });
            }
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteFile(Guid id)
        {
           await _serviceManager.FileService.DeleteFile(id);
            return Ok(new ResponseObjectModel { Code = StatusCodes.Status200OK, Status = "Success"});
        }
    }
}
