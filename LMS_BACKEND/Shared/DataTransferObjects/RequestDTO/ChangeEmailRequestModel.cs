using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class ChangeEmailRequestModel
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;
        public string? Token { get; set; } = null!;
    }
}
