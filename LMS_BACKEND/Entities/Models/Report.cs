namespace Entities.Models
{
    public class Report
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
        public string? DeviceStatus { get; set; } 
        public string? Description { get; set; }
        public string? FileKey { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual Schedule Schedules { get; set; } = null!;
    }

}
