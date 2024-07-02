using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface INewsService
    {
        Task<(IEnumerable<NewsReponseModel> news, MetaData metaData)> GetNewsAsync(NewsRequestParameters newsParameter, bool trackChanges);
        Task<NewsReponseModel> GetNewsById(Guid id);
        Task<bool> CreateNewsAsync(CreateNewsRequestModel model);
        void UpdateNews(Guid newsId, UpdateNewsRequestModel model);
        Task<bool> DeleteNewsAsync(Guid id);
    }
}
