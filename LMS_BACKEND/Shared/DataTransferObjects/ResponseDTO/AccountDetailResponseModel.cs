namespace Shared.DataTransferObjects.ResponseDTO
{
    public class AccountDetailResponseModel
    {
        public string Id { get; set; } = null!;
        public string? FullName { get; set; }
        public string Gender { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? RollNumber { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Major { get; set; }
        public string? Specialized { get; set; }


    }
}
