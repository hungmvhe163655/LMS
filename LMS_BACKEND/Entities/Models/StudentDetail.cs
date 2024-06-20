using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class StudentDetail
    {
        public string AccountId { get; set; }

        public string Major { get; set; } = null!;

        public string Specialized { get; set; } = null!;

        public string RollNumber { get; set; } = null!;

        public virtual Account Account { get; set; } = null!;
    }

}
