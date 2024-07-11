namespace Entities.Models
{
    public class TaskFile
    {
        public Guid TaskID { get; set; }
        public Guid FileId { get; set; }
        public virtual Files? File { get; set; }
        public virtual Tasks? Task { get; set; }
    }
}
