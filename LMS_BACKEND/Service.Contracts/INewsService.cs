using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface INewsService
    {
        Task<IEnumerable<NewsReponse>> GetNewsByTitle(string? Title);
        Task<NewsReponse> GetNewsDetail(int id);
        Task<bool> CreateNews(NewsRequestCreateModel news);
        Task<bool> UpdateNews(NewsRequestUpdateModel news);
        Task<bool> DeleteNews(int id);
    }
}
