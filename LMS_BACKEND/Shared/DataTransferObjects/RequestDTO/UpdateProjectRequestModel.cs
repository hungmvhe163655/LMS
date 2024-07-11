namespace Shared.DataTransferObjects.RequestDTO
{
    public class UpdateProjectRequestModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int ProjectStatusId { get; set; }

        public int MaxMember { get; set; }

        public bool IsRecruiting { get; set; }

        public int ProjectTypeId { get; set; }
    }
}
