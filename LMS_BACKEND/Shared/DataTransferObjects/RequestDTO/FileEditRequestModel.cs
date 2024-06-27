using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class FileEditRequestModel
    {
        [Required(ErrorMessage = "File Id can not be null")]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public float Size { get; set; }
        public string? FileKey { get; set; }
        public Guid FolderId { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
