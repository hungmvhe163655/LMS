using Microsoft.AspNetCore.Identity;


namespace Entities.Models
{
    public class Account : IdentityUser
    {
        //public override string Email { get; set; } = null!;
        public string? FullName { get; set; }
        public bool Gender { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? VerifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsVerified { get; set; }
        public bool IsBanned { get; set; }
        public string? EmailVerifyCode { get; set; }
        public DateTime EmailVerifyCodeAge { get; set; }
        public string? UserRefreshToken { get; set; }
        public DateTime UserRefreshTokenExpiryTime { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public virtual ICollection<Device> Devices { get; set; } = new List<Device>();

        public virtual ICollection<Folder> Folders { get; set; } = new List<Folder>();

        public virtual ICollection<Account> VerifiedAccounts { get; set; } = new List<Account>();

        public virtual ICollection<Member> Members { get; set; } = new List<Member>();

        public virtual ICollection<News> News { get; set; } = new List<News>();

        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

        public virtual ICollection<NotificationAccount> NotificationsAccounts { get; set; } = new List<NotificationAccount>();

        public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

        public virtual StudentDetail? StudentDetail { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();

        public virtual Account? VerifiedByUser { get; set; }

        public virtual ICollection<Tasks> TasksCurrent { get; set; } = new List<Tasks>();

        public virtual ICollection<TaskHistory> TaskHistories { get; set; } = new List<TaskHistory>();
        //  public virtual ICollection<Tasks> TasksCreated { get; set; } = new List<Tasks>();
    }
}
