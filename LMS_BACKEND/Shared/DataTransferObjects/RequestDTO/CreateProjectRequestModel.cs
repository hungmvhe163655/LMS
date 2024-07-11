using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class CreateProjectRequestModel
    {
        public string CreatedBy { get; set; } = null!;
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public int ProjectStatusId { get; set; }

        public int MaxMember { get; set; }

        public bool IsRecruiting { get; set; }

        public int ProjectTypeId { get; set; }
    }
}
