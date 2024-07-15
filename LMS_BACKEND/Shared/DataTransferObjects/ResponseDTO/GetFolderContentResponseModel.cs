using Entities.Models;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class GetFolderContentResponseModel
    {
        public ICollection<Folder> Folders { get; set; } = new List<Folder> { };
        public ICollection<Files> Files { get; set; } = new List<Files> { };
    }
}
