namespace Entities.Models
{
    public class ProjectType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    }

}
