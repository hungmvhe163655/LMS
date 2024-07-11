namespace Shared.DataTransferObjects.ResponseDTO
{
    public class AccountReturnModel
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? VerifiedBy { get; set; }
        public string? Gender { get; set; } = "male";
        public bool IsDeleted { get; set; }
        public bool IsBanned { get; set; }
        public bool IsVerified { get; set; }
        public IList<string> Roles { get; set; } = new List<string>();
    }
}