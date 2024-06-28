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
    [Route("api/folder")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public FolderController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetFolder(Guid FolderID)
        {
            return Ok(new ResponseObjectModel { Code = StatusCodes.Status200OK, Status = "Success", Value = await _serviceManager.FileService.GetFolderContent(FolderID) });
        }
        [HttpPost]
        public async Task<IActionResult> CreateFolder(CreateFolderRequestModel model)
        {
            var result = await _serviceManager.FileService.CreateFolder(model);
            if (result) return Ok(new ResponseObjectModel { Code = StatusCodes.Status200OK, Status = "Success", Value = model });
            return BadRequest(new ResponseObjectModel { Code = StatusCodes.Status400BadRequest, Status = "Failed", Value = new { Message = ModelState.ErrorCount } });
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteFolder(Guid FolderID)
        {
            await _serviceManager.FileService.DeleteFolder(FolderID);

            return StatusCode(StatusCodes.Status201Created, new ResponseObjectModel { Code = StatusCodes.Status201Created, Status = "Success" });
        }
    }
}
