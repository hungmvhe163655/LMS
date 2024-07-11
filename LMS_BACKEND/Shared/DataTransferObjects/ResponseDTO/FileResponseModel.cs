namespace Shared.DataTransferObjects.ResponseDTO
{
    public class FileResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public float Size { get; set; }
        public string FileKey { get; set; } = null!;
        public Guid FolderId { get; set; }
        public DateTime UploadDate { get; set; }
        public string MimeType { get; set; } = null!;
        public string FolderPath { get; set; } = null!;
    }
}
