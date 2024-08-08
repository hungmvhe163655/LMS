namespace Shared.DataTransferObjects.ResponseDTO
{
    public class NewsResponseModel
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }
        public string Title { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

    }

}
