using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class TaskHistory
    {
        public Guid Id { get; set; }
        public Guid TaskGuid { get; set; }
        public string Title { get; set; }
        public bool RequiredValidation { get; set; }
        public string Description { get; set; }
        public DateTime EditDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int TaskPriorityId { get; set; }
        public int TaskStatusId { get; set; }
        //public string AssignedTo { get; set; }
        public virtual Account AssignedToUser { get; set; } = null!;
        public virtual TaskPriorities TaskPriority { get; set; } = null!;
        public virtual TasksStatus TaskStatus { get; set; } = null!;
        //public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
        public virtual ICollection<Label> Labels { get; set; } = new List<Label>();
        public virtual Tasks TaskVersion { get; set; } = null!;
    }

}
