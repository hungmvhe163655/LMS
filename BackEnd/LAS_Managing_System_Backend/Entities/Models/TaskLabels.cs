using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class TaskLabels
    {
        public Guid LabelId { get; set; }
        public Guid TaskId { get; set; }
        public virtual Tasks Task { get; set; }
        public virtual Label Label { get; set; }
    }
}
