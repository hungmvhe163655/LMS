using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Report
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
        public int DeviceStatusId { get; set; }
        public string? Description { get; set; }
        public virtual Schedule Schedules { get; set; } = null!;
    }

}
