using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class FileUploadRequestModel
    {
        public string Name { get; set; }
        public float Size { get; set; }
        public string FileKey { get; set; }
        public Guid FolderId { get; set; }
        public string MimeType { get; set; }
    }
}
