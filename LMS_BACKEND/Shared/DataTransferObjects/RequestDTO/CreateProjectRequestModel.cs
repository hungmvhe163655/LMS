namespace Shared.DataTransferObjects.RequestDTO
{
    public class CreateProjectRequestModel
    {
        public string CreatedBy { get; set; } = null!;
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public string ProjectStatus { get; set; } = null!;

        public int MaxMember { get; set; }

        public bool IsRecruiting { get; set; }

        public int ProjectTypeId { get; set; }
    }
}
