using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class ProjectViewResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int MaxMember { get; set; }
        public bool IsRecruiting { get; set; }
        public int ProjectTypeId { get; set; }
    }
}
