namespace Shared.DataTransferObjects.RequestDTO
{
    public class TwoFactorModel
    {
        public string UserName { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
