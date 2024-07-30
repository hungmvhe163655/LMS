using Entities.Models;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface INewsService
    {
        Task<(IEnumerable<NewsReponseModel> news, MetaData metaData)> GetNewsAsync(NewsRequestParameters newsParameter, bool trackChanges);
        Task<NewsReponseModel> GetNewsById(Guid id);
        Task<NewsReponseModel> CreateNewsAsync(string userId, CreateNewsRequestModel model);
        Task UpdateNews(Guid id, UpdateNewsRequestModel model);
        Task DeleteNews(Guid id);
    }
}
