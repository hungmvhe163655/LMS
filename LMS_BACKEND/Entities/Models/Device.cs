using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;


namespace Entities.Models
{
    public class Device
    {
        public Guid Id { get; set; }
        public int DeviceStatusId { get; set; }
        public string? OwnedBy { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastUsed { get; set; }
        public bool isDeleted { get; set; }
        public virtual DeviceStatus DeviceStatus { get; set; } = null!;

        public virtual Account? OwnedByUser { get; set; } = null!;

        public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
