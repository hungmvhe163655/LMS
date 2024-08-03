namespace Shared.DataTransferObjects.RequestDTO
{
    public class ScheduleCreateRequestModel
    {
        public Guid DeviceId { get; set; }
        public string AccountId { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Purpose { get; set; }
    }
}
