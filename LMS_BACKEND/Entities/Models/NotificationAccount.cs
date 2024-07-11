using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class NotificationAccount
    {
        public Guid NotificationId { get; set; }
        public string? AccountId { get; set; }
        public bool IsRead { get; set; }

        public virtual Account Account { get; set; } = null!;
        [JsonIgnore]
        public virtual Notification Notification { get; set; } = null!;
    }

}
