using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public string? AccountId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Purpose { get; set; }
        public virtual Device Device { get; set; } = null!;
        public virtual Account Account { get; set; } = null!;
        public virtual Report? Report { get; set; }
    }

}
