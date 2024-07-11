namespace Entities.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Content { get; set; }
        public string? CreatedBy { get; set; }
        public Guid? ParentId { get; set; }
        public Guid TaskId { get; set; }
        public virtual Account CreatedByUser { get; set; } = null!;

        public virtual ICollection<Comment> InverseParent { get; set; } = new List<Comment>();

        public virtual Comment? Parent { get; set; }

        public virtual Tasks Task { get; set; } = null!;
    }
}
