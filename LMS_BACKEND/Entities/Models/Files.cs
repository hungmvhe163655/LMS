namespace Entities.Models
{
    public class Files
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public float Size { get; set; }
        public string FileKey { get; set; } = null!;
        public Guid FolderId { get; set; }
        public DateTime UploadDate { get; set; }
        public string? MimeType { get; set; }
        public virtual Folder? Folder { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
