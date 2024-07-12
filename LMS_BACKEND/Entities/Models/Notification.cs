namespace Entities.Models
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Url { get; set; }
        public int NotificationTypeId { get; set; }
        public string? CreatedBy { get; set; }
        public virtual Account? CreatedByUser { get; set; }
        public virtual NotificationType NotificationType { get; set; } = null!;

        public virtual ICollection<NotificationAccount> NotificationsAccounts { get; set; } = new List<NotificationAccount>();
    }

}
