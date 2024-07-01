using LMS_BACKEND_MAIN.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public FileController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file, [FromBody] FileUploadRequestModel metadata)
        {
            if (file.Length == 0)
            {
                return BadRequest(new ResponseMessage { Message = "File Is Null Or Empty" });
            }
            if (metadata == null)
            {
                return BadRequest(new ResponseMessage { Message = "Metadata is required" });
            }

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            memoryStream.Position = 0;


            var result = await _serviceManager.FileService.CreateFile(metadata, memoryStream);

            return Ok(new ResponseMessage { Message = "File uploaded successfully." });
        }

        [HttpGet]
        [Route("download/{key}")]
        public async Task<IActionResult> DownloadFile(string key)
        {

            var fileStream = await _serviceManager.FileService.GetFile(key);

            if (fileStream.Item1 == null || fileStream.Item2 == null)
            {
                return NotFound(new ResponseMessage { Message = "File not found" });
            }

            string mimeType = MIME.GetMimeType(fileStream.Item2.MimeType);

            var contentType = "application/octet-stream";

            return Ok(new { FileResult = File(fileStream.Item1, contentType), FileDetail = fileStream.Item2 });

        }
    }
}
