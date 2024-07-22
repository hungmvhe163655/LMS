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

        public async Task<News> CreateNewsAsync(CreateNewsRequestModel model)
        {
            var hold_user = await _repository.Account.GetByCondition(entity => entity.Id.Equals(model.CreatedBy), true).FirstOrDefaultAsync()
                ?? throw new BadRequestException($"Can't find user with id {model.CreatedBy}");

            var hold = new News
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Content = model.Content ?? "",
                CreatedBy = model.CreatedBy,
                CreatedDate = DateTime.Now,
            };

            await _repository.News.CreateAsync(hold);

            if (model.FileKey != null)
            {
                var listFile = new List<NewsFileRequestModel>();
                foreach (var file in model.FileKey)
                {
                    var hold_file = new NewsFileRequestModel
                    {
                        Id = Guid.NewGuid(),
                        NewsID = hold.Id,
                        FileKey = file,
                    };
                    listFile.Add(hold_file);
                }
                var hold_newsFile = _mapper.Map<IEnumerable<NewsFile>>(listFile);

                await _repository.NewsFile.AddRange(hold_newsFile);
            }
            await _repository.Save();
            return hold;
        }

        public async Task DeleteNews(Guid id)
        {
            var newses = _repository.News.GetByCondition(entity => entity.Id.Equals(id), false);
            var news = newses.First();
            if (news == null)
                throw new BadRequestException("News wth id: " + id + "doesn't exist");
            _repository.News.Delete(news);
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

        public async Task UpdateNews(UpdateNewsRequestModel model)
        {
            var hold = await _repository.News.GetNews(model.Id, true) ?? throw new BadRequestException("News with id: " + model.Id + " is not exist");
            _mapper.Map(model, hold);
            if (model.FileKey != null)
            {
                var listFile = new List<NewsFileRequestModel>();
                foreach (var file in model.FileKey)
                {
                    var hold_file = new NewsFileRequestModel
                    {
                        Id = Guid.NewGuid(),
                        NewsID = hold.Id,
                        FileKey = file,
                    };
                    listFile.Add(hold_file);
                }
                var hold_newsFile = _mapper.Map<IEnumerable<NewsFile>>(listFile);

                await _repository.NewsFile.AddRange(hold_newsFile);
            }
            await _repository.Save();
        }

    }
}
