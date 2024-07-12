using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class ForgotPasswordRequestModel
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
