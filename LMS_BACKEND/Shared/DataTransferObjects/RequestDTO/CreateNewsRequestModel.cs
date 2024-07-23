namespace Shared.DataTransferObjects.RequestDTO
{
    public class CreateNewsRequestModel
    {
        public string CreatedBy { get; set; } = null!;
        public string? Content { get; set; }
        public string Title { get; set; } = null!;
        public List<string>? FileKey { get; set; }

    }
}
