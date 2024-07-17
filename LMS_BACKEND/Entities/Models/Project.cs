namespace Entities.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public string ProjectStatus { get; set; } = null!;

        public int MaxMember { get; set; }

        public bool? IsRecruiting { get; set; } = null!;

        public int ProjectTypeId { get; set; }

        public virtual ICollection<Member> Members { get; set; } = new List<Member>();

        public virtual ProjectType ProjectType { get; set; } = null!;

        public virtual ICollection<TaskList> TaskLists { get; set; } = new List<TaskList>();

        public virtual ICollection<Folder> Folders { get; set; } = new List<Folder>();

        //public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

        //public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();
    }

}
