using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class RegisterRequestModel
    {
        public string? RollNumber { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;
        public bool Gender { get; set; } = true;
        public string PhoneNumber { get; set; } = null!;
        public string VerifiedByUserID { get; set; } = null!;
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;
        public ICollection<string> Roles { get; init; } = null!;
    }
}
