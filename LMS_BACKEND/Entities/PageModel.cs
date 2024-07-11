namespace Entities
{
    public class PageModel<T> where T : class
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public IEnumerable<T>? Data { get; set; }
    }
}
