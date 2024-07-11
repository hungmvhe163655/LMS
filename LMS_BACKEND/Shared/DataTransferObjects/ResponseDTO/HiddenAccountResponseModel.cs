namespace Shared.DataTransferObjects.ResponseDTO
{
    public class HiddenAccountResponseModel
    {
        public string AccountId { get; set; } = null!;
        public string VerifierId { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
