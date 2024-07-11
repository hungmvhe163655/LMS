using Entities.Models;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class GetFolderContentResponseModel
    {
        public List<Folder> Folders { get; set; } = new List<Folder> { };
        public List<Files> Files { get; set; } = new List<Files> { };
    }
}
