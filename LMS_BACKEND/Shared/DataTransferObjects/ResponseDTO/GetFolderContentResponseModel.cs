using Entities.Models;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class GetFolderContentResponseModel
    {
        public ICollection<FolderResponseModel> Folders { get; set; } = new List<FolderResponseModel> { };
        public ICollection<FileResponseModel> Files { get; set; } = new List<FileResponseModel> { };
    }
}
