﻿namespace Entities.Models
{
    public class TaskList
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int MaxTasks { get; set; }
        public Guid ProjectId { get; set; }
        public int Order { get; set; } = 0;
        public virtual Project Project { get; set; } = null!;
        public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }

}
