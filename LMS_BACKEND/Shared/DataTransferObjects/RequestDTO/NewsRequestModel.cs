namespace Shared.DataTransferObjects.RequestDTO
{
    public class NewsRequestModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? CreatedBy { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; } = null!;

    }
}
