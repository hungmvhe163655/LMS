namespace Shared.DataTransferObjects.RequestDTO
{
    public class CreateNewsRequestModel
    {
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; } = null!;
        public List<string>? FileKey { get; set; }

    }
}
