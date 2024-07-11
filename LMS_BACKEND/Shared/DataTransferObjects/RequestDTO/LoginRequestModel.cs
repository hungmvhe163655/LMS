using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "Email Is Required")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; } = null!;
        public string? AuCode { get; set; } = null!;
    }
}
