using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class GetFolderContentResponseModel
    {
        public List<Folder> Folders { get; set; } = new List<Folder> { };
        public List<Files> Files { get; set; } = new List<Files> { };
    }
}
