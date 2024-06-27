namespace Shared.DataTransferObjects.ResponseDTO
{
    public class NewsReponse
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public string Title { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public string CreatedDate { get; set;} = null!;

        //public virtual ICollection<NewsFileReponse>? NewsFiles { get; set; } = new List<NewsFileReponse>();
    }

    //public class NewsFileReponse
    //{
    //    public int Id { get; set; }
    //    public string? FileKey { get; set; }
    //}
}
