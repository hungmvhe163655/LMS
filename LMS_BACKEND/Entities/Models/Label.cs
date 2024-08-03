using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Label
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? HexColor { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }

}
