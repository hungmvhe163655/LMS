using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class ChangePasswordRequestModel
    {
        [Required(ErrorMessage = "Old Password is required")]
        public string OldPassword { get; set; } = null!;
        [Required(ErrorMessage = "New Password is required")]
        public string NewPassword { get; set; } = null!;
        public string? Token { get; set; }
    }
}
