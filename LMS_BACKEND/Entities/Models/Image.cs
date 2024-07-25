using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Image // this is new 
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Extentions { get; set; } = null!;
        public string Type { get; set; } = null!;
        public Guid? ContentId { get; set; } = Guid.Empty!;
        public virtual Device? Device { get; set; } = null!;
    }
}
