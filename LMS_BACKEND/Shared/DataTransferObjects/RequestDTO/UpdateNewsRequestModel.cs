namespace Shared.DataTransferObjects.RequestDTO
{
    public class UpdateNewsRequestModel
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }
        public string Title { get; set; } = null!;

    }
}
