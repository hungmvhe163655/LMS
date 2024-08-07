﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class TaskHistory
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TaskGuid { get; set; }
        public string? Title { get; set; }
        public bool RequiredValidation { get; set; }
        public string? Description { get; set; }
        public DateTime EditDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string TaskStatus { get; set; } = null!;
        public string TaskPriority { get; set; } = null!;
        public string? AssignedTo { get; set; }
        [JsonIgnore]
        public virtual Account AssignedToUser { get; set; } = null!;
        //public virtual TaskPriorities TaskPriority { get; set; } = null!;
        //public virtual TasksStatus TaskStatus { get; set; } = null!;
        public virtual ICollection<Label> Labels { get; set; } = new List<Label>();
        public virtual Tasks TaskVersion { get; set; } = null!;
    }

}
