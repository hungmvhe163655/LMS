using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service
{
    public class NewsService : INewsService
    {

        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public NewsService(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> CreateNewsAsync(CreateNewsRequestModel model)
        {
            try
            {
                var users = await _repository.account.GetByConditionAsync(entity => entity.Id.Equals(model.CreatedBy), true);
                var user = users.FirstOrDefault();
                if (user != null && model.Title != null)
                {
                    await _repository.news.CreateAsync(new News
                    {
                        Id = Guid.NewGuid(),
                        Content = model.Content,
                        Title = model.Title,
                        CreatedDate = model.CreatedDate,
                        CreatedBy = user.Id ?? ""
                    });
                    await _repository.Save();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteNewsAsync(Guid id)
        {
            try
            {
                var newses = await _repository.news.GetByConditionAsync(entity => entity.Id.Equals(id), true);
                var news = newses.FirstOrDefault();
                if (news != null)
                {
                    _repository.news.Delete(news);
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public async Task<(IEnumerable<NewsReponseModel> news, MetaData metaData)> GetNewsAsync(NewsRequestParameters newsParameter, bool trackChanges)
        {
            var newsFromDb= await _repository.news.GetNewsAsync(newsParameter, trackChanges);
            var newsDto= _mapper.Map<IEnumerable<NewsReponseModel>>(newsFromDb);
            return (news: newsDto, metaData: newsFromDb.MetaData);
        }

        public async Task<NewsReponseModel> GetNewsById(Guid id)
        {
            try
            {
                var news = await _repository.news.GetByConditionAsync(news => news.Id.Equals(id), false);
                if (news == null) throw new BadRequestException("Can't found news with id " + id);
                return _mapper.Map<NewsReponseModel>(news.First());
            }
            catch
            {
                throw;
            }
        }

        public void UpdateNews(Guid newsId,UpdateNewsRequestModel model)
        {
            var hold = _repository.news.GetNewsById(newsId, true);
            if (hold == null) throw new BadRequestException("News with id: "+ newsId + " is not exist");
            //updateNews.Content = model.Content;
            //updateNews.Title = model.Title;

            _mapper.Map(model, hold);
            _repository.Save();
        }

    }
}
