using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public int ProjectStatusId { get; set; }

        public int MaxMember { get; set; }

        public bool? IsRecruiting { get; set; } = null!;

        public int ProjectTypeId { get; set; }

        public virtual ICollection<Member> Members { get; set; } = new List<Member>();

        public virtual ProjectStatus ProjectStatus { get; set; } = null!;

        public virtual ProjectType ProjectType { get; set; } = null!;

        public virtual ICollection<TaskList> TaskLists { get; set; } = new List<TaskList>();

        //public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

        //public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();
    }

}
