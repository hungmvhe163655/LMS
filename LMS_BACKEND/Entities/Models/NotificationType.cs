namespace Entities.Models
{
    public class NotificationType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; }
    }

}
