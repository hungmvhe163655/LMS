using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class CreateFolderRequestModel
    {
        public string? Name { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ? AncestorId { get; set; }
    }
}
