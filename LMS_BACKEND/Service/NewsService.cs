﻿using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task CreateNewsAsync(CreateNewsRequestModel model)
        {
            var hold_user = await _repository.account.GetByCondition(entity => entity.Id.Equals(model.CreatedBy), true).FirstOrDefaultAsync()
                ?? throw new BadRequestException($"Can't find user with id {model.CreatedBy}");

            var hold = _mapper.Map<News>(model);
            hold.Id = Guid.NewGuid();
            hold.CreatedDate = DateTime.Now;

            await _repository.news.CreateAsync(hold);

            if(model.FileKey != null)
            {
                foreach (var file in model.FileKey) 
                {
                    var hold_file= new NewsFile
                    {
                        
                    }
                }
            }
            await _repository.Save();
        }

        public async Task DeleteNews(Guid id)
        {
            var newses = _repository.news.GetByCondition(entity => entity.Id.Equals(id), false);
            var news = newses.First();
            if (news == null)
                throw new BadRequestException("News wth id: " + id + "doesn't exist");
            _repository.news.Delete(news);
            await _repository.Save();
        }

        public async Task<(IEnumerable<NewsReponseModel> news, MetaData metaData)> GetNewsAsync(NewsRequestParameters newsParameter, bool trackChanges)
        {
            var newsFromDb = await _repository.news.GetNewsAsync(newsParameter, trackChanges);
            foreach (var news in newsFromDb)
            {
                var hold = _repository.account.GetByCondition(a => a.Id.Equals(news.CreatedBy), false).FirstOrDefault() ?? throw new BadRequestException($"Can't find any news created by account {news.CreatedBy}");
                news.CreatedBy = hold.FullName != null ? hold.FullName : hold.Email;
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
