namespace Shared.DataTransferObjects.ResponseDTO
{
    public class DeviceReturnModel
    {
        public Guid Id { get; set; }
        public string DeviceStatus { get; set; } = null!;
        public string? OwnedBy { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime LastUsed { get; set; }
        public bool IsDeleted { get; set; }
        public string? Filekey { get; set; }
    }
}
