using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class UpdateVerifyStatusRequestModel
    {
        [Required(ErrorMessage = "UserId is required")]
        public List<UserAcceptanceRequestModel> Users { get; set; } = new List<UserAcceptanceRequestModel>();
        public string VerifierID { get; set; } = null!;
    }
}
