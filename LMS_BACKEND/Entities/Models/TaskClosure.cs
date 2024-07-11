namespace Entities.Models
{
    public class TaskClosure
    {
        public Guid AncestorID { get; set; }
        public Guid DescendantID { get; set; }
        public int Depth { get; set; }
        public virtual Tasks AncestorTaskNavigation { get; set; } = null!;
        public virtual Tasks DescendantTaskNavigation { get; set; } = null!;
    }
}
