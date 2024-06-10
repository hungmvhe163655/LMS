using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
