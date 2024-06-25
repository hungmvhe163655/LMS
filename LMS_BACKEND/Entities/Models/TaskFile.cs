using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class TaskFile
    {
        public Guid TaskID { get; set; }
        public Guid FileId { get; set; }
        public virtual Files? File { get; set; }
        public virtual Tasks? Task { get; set; }
    }
}
