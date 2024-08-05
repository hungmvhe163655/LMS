namespace Shared.DataTransferObjects.RequestDTO
{
    public class CreateProjectRequestModel
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int MaxMember { get; set; }

        public bool IsRecruiting { get; set; }

        public int ProjectTypeId { get; set; }
    }
}
