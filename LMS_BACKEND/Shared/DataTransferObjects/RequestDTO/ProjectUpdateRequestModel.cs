using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class ProjectUpdateRequestModel
    {
        public string? Name { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public int MaxMember { get; set; }

        public bool? IsRecruiting { get; set; }
        public string? LeaderId { get; set; }
    }
}
