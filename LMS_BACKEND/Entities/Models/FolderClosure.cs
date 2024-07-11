namespace Entities.Models
{
    public class FolderClosure
    {
        public Guid AncestorID { get; set; }
        public Guid DescendantID { get; set; }
        public int Depth { get; set; }

        public virtual Folder AncestorNavigation { get; set; } = null!;

        public virtual Folder DescendantNavigation { get; set; } = null!;
    }

}
