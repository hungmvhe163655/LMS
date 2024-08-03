using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class NewsFile
    {
        [Key]
        public Guid Id { get; set; }
        public string? FileKey { get; set; }
        public Guid NewsID { get; set; }
        public virtual News? News { get; set; }
    }
}
