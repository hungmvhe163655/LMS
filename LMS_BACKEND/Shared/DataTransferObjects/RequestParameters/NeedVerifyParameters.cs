namespace Shared.DataTransferObjects.RequestParameters
{
    public class NeedVerifyParameters : RequestParameters
    {
        public string? SearchContent { get; set; } = null!;
        public string? UserId { get; set; } = null!;
        public string? Role {  get; set; } = null!;
    }
}
