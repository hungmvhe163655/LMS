using LMS_BACKEND_MAIN.Presentation.Dictionaries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

namespace LMS_BACKEND_MAIN.Presentation.Controllers
{
    [Route(APIs.FolderAPI)]
    [ApiController]
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

        [HttpPost]
        public async Task<IActionResult> CreateFolder(CreateFolderRequestModel model)
        {
            var result = await _serviceManager.FileService.CreateFolder(model);

            if (!result)
            {
                return BadRequest(new ResponseMessage { Message = "Failed Create Folder" });
            }
            return Ok(model);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteFolder(Guid FolderID)
        {
            await _serviceManager.FileService.DeleteFolder(FolderID);

            return StatusCode(StatusCodes.Status201Created, new ResponseMessage { Message = "DELETEFILE" });
        }

    }
}
