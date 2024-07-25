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

        public virtual Account? OwnedByUser { get; set; } = null!;
        public virtual ICollection<Image> Images { get; set; } = new List<Image>(); //this is new 
        public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
