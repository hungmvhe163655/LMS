namespace Entities.Models
{
    public class Device
    {
        public Guid Id { get; set; }
        public int DeviceStatusId { get; set; }
        public string? OwnedBy { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime LastUsed { get; set; }
        public bool IsDeleted { get; set; }
        public virtual DeviceStatus DeviceStatus { get; set; } = null!;

        public virtual Account? OwnedByUser { get; set; } = null!;

        public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
