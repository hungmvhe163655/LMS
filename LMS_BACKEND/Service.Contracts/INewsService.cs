using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface INewsService
    {
        Task<IEnumerable<NewsReponseModel>> GetNewsAsync(NewsRequestParameters newsParameter, bool trackChanges);
        Task<NewsReponseModel> GetNewsById(string id);
        Task<bool> CreateNewsAsync(NewsRequestModel model);
        Task UpdateNewsAsync(NewsRequestModel model);
        Task<bool> DeleteNewsAsync(int id);
    }
}
