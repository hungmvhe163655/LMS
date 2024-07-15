namespace Entities.Models
{
    public class Member : ISoftDelete
    {
        public Guid ProjectId { get; set; }
        public string UserId { get; set; } = null!;
        public bool IsLeader { get; set; } = false;
        public DateTime JoinDate { get; set; }
        public bool IsValidTeamMember { get; set; } = true;
        public virtual Project? Project { get; set; }
        public virtual Account? User { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }

}
