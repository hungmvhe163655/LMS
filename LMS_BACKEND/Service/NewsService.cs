using AutoMapper;
using Contracts.Interfaces;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
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

        public async Task<bool> CreateNews(NewsRequestCreateModel newsModel)
        {
            try
            {
                News news = _mapper.Map<News>(newsModel);

                await _repository.news.CreateAsync(news);

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteNews(int id)
        {
            try
            {
                News news = _repository.news.GetByCondition(x => x.Id.Equals(id), false).First();
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

        public async Task<IEnumerable<NewsReponse>> GetNewsByTitle(string? Title)
        {
            try
            {
                IEnumerable<News> news = (IEnumerable<News>)_repository.news.FindAllAsync(true);
                if (!String.IsNullOrEmpty(Title))
                {
                    news = news.Where(x => x.Title.ToLower().Trim() == Title.ToLower().Trim());
                }
                IEnumerable<NewsReponse> newsReponses = _mapper.Map<IEnumerable<NewsReponse>>(news);

                return newsReponses;
            }
            catch
            {
                throw;
            }
        }

        public async Task<NewsReponse> GetNewsDetail(int id)
        {
            try
            {
                News news = _repository.news.GetByCondition(x => x.Id.Equals(id), false).First();
                if (news != null)
                {
                    NewsReponse newsReponse = _mapper.Map<NewsReponse>(news);

                    return newsReponse;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateNews(NewsRequestUpdateModel news)
        {
            try
            {
                News newsUpdate = _repository.news.GetByCondition(x => x.Id.Equals(news.Id), false).First();
                if (news != null)
                {
                    newsUpdate.Title = news.Title;
                    newsUpdate.Content = news.Content;

                    _repository.news.Update(newsUpdate);

                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
    }
}
