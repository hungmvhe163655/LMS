using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ProjectPermission
    {
        public Guid ProjectId { get; set; }
        public int PermissionId { get; set; }
        public virtual Project Project { get; set; }
        public virtual Permission Permission { get; set; }
    }

}
