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
