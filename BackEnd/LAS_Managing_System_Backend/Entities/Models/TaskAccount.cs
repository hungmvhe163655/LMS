using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class TaskAccount
    {
        public Guid AccountId { get; set; }
        public Guid TaskId { get; set; }
        public virtual Account Account { get; set; }
        public virtual Tasks Task { get; set; }
    }
}
