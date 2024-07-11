namespace Shared.DataTransferObjects.ResponseDTO
{
    public class NewsReponseModel
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }
        public string Title { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

    }

}
