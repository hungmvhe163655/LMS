using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface INewsService
    {
        Task<NewsReponse> GetNewsById(string id);
        Task<bool> CreateNewsAsync(NewsRequestModel model);
        Task UpdateNewsAsync(NewsRequestModel model);
        Task<bool> DeleteNewsAsync(int id);
    }
}
