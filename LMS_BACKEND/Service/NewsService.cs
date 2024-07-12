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
        private readonly IMapper _mapper;

        public NewsService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
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

        public async Task DeleteNews(Guid id)
        {
            var newses = _repository.news.GetByCondition(entity => entity.Id.Equals(id), false);
            var news = newses.First();
            if (news == null) 
                throw new BadRequestException("News wth id: "+ id + "doesn't exist");
            _repository.news.Delete(news);
            await _repository.Save();
        }

        public async Task<(IEnumerable<NewsReponseModel> news, MetaData metaData)> GetNewsAsync(NewsRequestParameters newsParameter, bool trackChanges)
        {
            var newsFromDb = await _repository.news.GetNewsAsync(newsParameter, trackChanges);
            foreach (var news in newsFromDb)
            {
                var hold = await _repository.account.GetByConditionAsync(a => a.Id.Equals(news.CreatedBy), false);
                var account = hold.FirstOrDefault();
                if (account == null) throw new BadRequestException("");
                news.CreatedBy = account.FullName != null ? account.FullName : account.Email;
            }
            var newsDto = _mapper.Map<IEnumerable<NewsReponseModel>>(newsFromDb);
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

        public async Task UpdateNews(UpdateNewsRequestModel model)
        {
            var hold = _repository.news.GetNews(model.Id, true);
            if (hold == null) throw new BadRequestException("News with id: " + model.Id + " is not exist");
            _mapper.Map(model, hold);
            await _repository.Save();
        }

    }
}
