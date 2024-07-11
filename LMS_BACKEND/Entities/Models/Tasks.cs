using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Tasks
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string CreatedBy { get; set; } = null!;
        public bool? RequiredValidation { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int TaskPriorityId { get; set; }
        public Guid TaskListId { get; set; }
        public Guid ProjectId { get; set; }
        public int TaskStatusId { get; set; }
        public string? AssignedTo { get; set; }
        public virtual Account? AssignedToUser { get; set; }
        //[JsonIgnore]
        //public virtual Account? CreatedByUser { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        // public virtual ICollection<Tasks> InversePredecessorTask { get; set; } = new List<Tasks>();

        //public virtual Tasks? PredecessorTask { get; set; }

        public virtual ICollection<TaskHistory> TaskHistories { get; set; } = new List<TaskHistory>();

        public virtual TaskList TaskList { get; set; } = null!;

        public virtual TaskPriorities TaskPriority { get; set; } = null!;

        public virtual TasksStatus TaskStatus { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

        public virtual ICollection<Files> Files { get; set; } = new List<Files>();

        public virtual ICollection<Label> Labels { get; set; } = new List<Label>();

        public virtual ICollection<TaskClosure> TaskClosuresAncestor { get; set; } = new List<TaskClosure>();
        public virtual ICollection<TaskClosure> TaskClosuresDescendant { get; set; } = new List<TaskClosure>();
    }

}
