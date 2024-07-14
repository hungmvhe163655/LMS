namespace Shared.DataTransferObjects.RequestDTO
{
    public class UpdateProfileRequestModel
    {
        public string Id { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public bool Gender { get; set; } = true;
        public string? Major { get; set; }
        public string? Specialized { get; set; }
    }
}
