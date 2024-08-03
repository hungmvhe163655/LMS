using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Images // this is new 
    {
        [Key]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Extentions { get; set; } = null!;
        public string Type { get; set; } = null!;
        public virtual Device? Device { get; set; }
        public virtual Report? Report { get; set; }
    }
}
