﻿using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Folder
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public Guid ProjectId { get; set; }
        public bool IsRoot { get; set; }
        public virtual Account CreatedByUser { get; set; } = null!;

        public virtual ICollection<Files> Files { get; set; } = new List<Files>();

        public virtual ICollection<FolderClosure> FolderClosureAncestor { get; set; } = new List<FolderClosure>();

        public virtual ICollection<FolderClosure> FolderClosureDescendant { get; set; } = new List<FolderClosure>();

        public virtual Project? Project { get; set; }
    }

}
