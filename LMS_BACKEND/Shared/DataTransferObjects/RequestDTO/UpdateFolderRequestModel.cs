using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class UpdateFolderRequestModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
