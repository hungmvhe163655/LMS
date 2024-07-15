namespace Entities.Models
{
    public class TasksStatus
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Tasks>? Tasks { get; set; }
    }
}
