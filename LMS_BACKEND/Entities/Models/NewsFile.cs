using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class NewsFile
    {
        public int Id { get; set; }
        public string? FileKey { get; set; }
        public Guid NewsID { get; set; }
        public virtual News? News { get; set; }
    }
}
