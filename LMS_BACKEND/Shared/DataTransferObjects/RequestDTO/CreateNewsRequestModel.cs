namespace Shared.DataTransferObjects.RequestDTO
{
    public class CreateNewsRequestModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? CreatedBy { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string Title { get; set; } = null!;

    }
}
