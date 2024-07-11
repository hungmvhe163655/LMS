namespace Shared.DataTransferObjects.ResponseDTO
{
    public class DeviceReturnModel
    {
        public Guid Id { get; set; }
        public int DeviceStatusId { get; set; }
        public string? OwnedBy { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime LastUsed { get; set; }
        public bool IsDeleted { get; set; }
    }
}
