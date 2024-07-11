using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class UpdateVerifyStatusRequestModel
    {
        [Required(ErrorMessage = "UserId is required")]
        public string UserID { get; set; } = null!;
        public string verifierID { get; set; } = null!;
    }
}
