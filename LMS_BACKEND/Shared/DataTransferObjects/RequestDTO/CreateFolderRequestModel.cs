namespace Shared.DataTransferObjects.RequestDTO
{
    public class CreateFolderRequestModel
    {
        public string? Name { get; set; }
        public string? CreatedBy { get; set; }
        public Guid ProjectId { get; set; }
        public Guid AncestorId { get; set; }
    }
}
