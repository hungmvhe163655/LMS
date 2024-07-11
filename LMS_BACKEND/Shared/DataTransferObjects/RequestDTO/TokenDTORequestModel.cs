namespace Shared.DataTransferObjects.RequestDTO
{
    public class TokenDTORequestModel
    {
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }
}
