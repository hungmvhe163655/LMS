namespace Shared.DataTransferObjects.RequestDTO
{
    public class FileUploadRequestModel
    {
        public string Name { get; set; } = null!;
        public float Size { get; set; } = 0!;
        public string FileKey { get; set; } = null!;
        public Guid FolderId { get; set; } = Guid.Empty!;
        public string MimeType { get; set; } = null!;
    }
}
