using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class UpdateVerifyStatusRequestModel
    {
        [Required(ErrorMessage = "UserId is required")]
        public List<string> UserID { get; set; } = new List<string>();
        public string verifierID { get; set; } = null!;
    }
}
