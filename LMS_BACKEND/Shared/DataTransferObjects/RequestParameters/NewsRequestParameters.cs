namespace Shared.DataTransferObjects.RequestParameters
{
    public class NewsRequestParameters : RequestParameters
    {
        public NewsRequestParameters() => OrderBy = "CreatedDate";
        public DateTime minCreatedDate { get; set; }
        public DateTime maxCreatedDate { get; set; } = DateTime.MaxValue;

        public bool ValidCreatedDateRange => DateTime.Compare(minCreatedDate, maxCreatedDate) < 0;
        public string? SearchTerm { get; set; }
        public bool SearchByContent { get; set; } = false;

    }
}
