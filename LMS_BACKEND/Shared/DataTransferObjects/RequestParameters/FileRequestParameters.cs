namespace Shared.DataTransferObjects.RequestParameters
{
    public class FileRequestParameters : RequestParameters
    {
        public bool? OrderByName { get; set; } = true!;
        public bool? OrderBySize { get; set; } = true!;
        public string? SearchTerm { get; set; }
    }
}
