using AutoMapper;
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

        public async Task<NewsReponseModel> CreateNewsAsync(string userId, CreateNewsRequestModel model)
        {
            //var hold_user = await _repository.Account.GetByCondition(entity => entity.Id.Equals(userId), true).FirstOrDefaultAsync()
            //    ?? throw new BadRequestException($"Can't find user with id {userId}");

            var hold = new News
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Content = model.Content ?? "",
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
            };

            if (model.FileKey?.Any() == true)
            {
                var newsFiles = model.FileKey.Select(fileKey => new NewsFileRequestModel
                {
                    Id = Guid.NewGuid(),
                    NewsID = hold.Id,
                    FileKey = fileKey
                });

                var mappedNewsFiles = _mapper.Map<IEnumerable<NewsFile>>(newsFiles);
                await _repository.NewsFile.AddRange(mappedNewsFiles);
            }
            await _repository.News.CreateAsync(hold);
            await _repository.Save();
            return _mapper.Map<NewsReponseModel>(hold);
        }

        public async Task DeleteNews(Guid id)
        {
            var hold = await _repository.News.GetNews(id, false) ?? throw new BadRequestException("News wth id: " + id + "doesn't exist");
            var hold_newsFile = await _repository.NewsFile.GetByConditionAsync(n => n.NewsID.Equals(id), false);
            if(hold_newsFile.Any())
            {
                _repository.NewsFile.DeleteRange(hold_newsFile);
            }
            _repository.News.Delete(hold);
            await _repository.Save();
        }

        public async Task<(IEnumerable<NewsReponseModel> news, MetaData metaData)> GetNewsAsync(NewsRequestParameters newsParameter, bool trackChanges)
        {
            var newsFromDb = await _repository.News.GetNewsAsync(newsParameter, trackChanges) ?? throw new BadRequestException("Can't find any news");
            var newsDto = _mapper.Map<IEnumerable<NewsReponseModel>>(newsFromDb);
            return (news: newsDto, metaData: newsFromDb.MetaData);
        }

        public async Task<NewsReponseModel> GetNewsById(Guid id)
        {
            var news = await _repository.News.GetNews(id, false) ?? throw new BadRequestException("Can't found news with id " + id);
            return _mapper.Map<NewsReponseModel>(news);
        }

        public async Task UpdateNews(Guid id, UpdateNewsRequestModel model)
        {
            var hold = await _repository.News.GetNews(id, true) ?? throw new BadRequestException("News with id: " + id + " is not exist");
            _mapper.Map(model, hold);
            if (model.FileKey?.Any() == true)
            {
                var existingFiles = await _repository.NewsFile.GetByCondition(f => f.NewsID.Equals(hold.Id), false).ToListAsync();

                if (existingFiles.Any())
                {
                    _repository.NewsFile.DeleteRange(existingFiles);
                }

                var newsFiles = model.FileKey.Select(fileKey => new NewsFileRequestModel
                {
                    Id = Guid.NewGuid(),
                    NewsID = hold.Id,
                    FileKey = fileKey
                });

                var mappedNewsFiles = _mapper.Map<IEnumerable<NewsFile>>(newsFiles);
                await _repository.NewsFile.AddRange(mappedNewsFiles);
            }
            await _repository.Save();
        }

    }
}
