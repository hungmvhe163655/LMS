using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class ProjectResponseModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = null!;

        public string? Description { get; set; } = null!;

        //public DateTime CreatedDate { get; set; }

        //public string ProjectStatus { get; set; } = null!;

        //public int MaxMember { get; set; }

        //public bool? IsRecruiting { get; set; } = null!;

        //public string ProjectType { get; set; } = null!;
        //public IEnumerable<Member>? Members { get; set; }
        //public IEnumerable<TaskList>? TaskLists { get; set; }
    }
}
