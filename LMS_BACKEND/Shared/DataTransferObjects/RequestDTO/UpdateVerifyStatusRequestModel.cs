using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class UpdateVerifyStatusRequestModel
    {
        [Required(ErrorMessage = "UserId is required")]
        public List<UserAcceptanceRequestModel> UserID { get; set; } = new List<UserAcceptanceRequestModel>();
        public string VerifierID { get; set; } = null!;
        public bool Accept {  get; set; } = true;
    }
}
