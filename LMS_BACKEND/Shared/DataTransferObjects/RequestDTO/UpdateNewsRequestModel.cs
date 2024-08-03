namespace Shared.DataTransferObjects.RequestDTO
{
    public class UpdateNewsRequestModel
    {
        public string? Content { get; set; }
        public string Title { get; set; } = null!;
        public List<string>? FileKey { get; set; }
    }
}
