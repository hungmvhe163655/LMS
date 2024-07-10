using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Member
    {
        public Guid ProjectId { get; set; }
        public string UserId { get; set; } = null!;
        public bool IsLeader { get; set; }
        public DateTime JoinDate { get; set; }
        public virtual Project? Project { get; set; }
        public virtual Account? User { get; set; }
    }

}
