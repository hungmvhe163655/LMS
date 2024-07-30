using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Device
    {
        [Key]
        public Guid Id { get; set; }
        public string DeviceStatus { get; set; } = null!;
        public string OwnedBy { get; set; } = null!;
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime LastUsed { get; set; }
        public bool IsDeleted { get; set; }
        public string? Filekey { get; set; }
        public virtual Account? OwnedByUser { get; set; } = null!;
        public virtual Images? Image { get; set; }//this is new 
        public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
