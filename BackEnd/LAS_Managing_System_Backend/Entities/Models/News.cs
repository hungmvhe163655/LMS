using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class News
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public string Title { get; set; } = null!;

        public virtual Account CreatedByNavigation { get; set; } = null!;

        public virtual ICollection<NewsFile> NewsFiles { get; set; } = new List<NewsFile>();
    }

}
