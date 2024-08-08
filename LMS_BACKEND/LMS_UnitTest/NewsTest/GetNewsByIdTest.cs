using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Moq;
using Service;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LMS_UnitTest.NewsTest
{
    public class GetNewsByIdTest
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly NewsService _newsServiceMock;

        public GetNewsByIdTest()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _newsServiceMock = new NewsService(
                _repositoryManagerMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task GetNewsById_ShouldReturnNews_WhenIdIsValid()
        {
            // Arrange
            var id = Guid.NewGuid();
            var news = new News { Id = id, Title = "Title", Content = "Content", CreatedBy = "User", CreatedDate = DateTime.Now };

            var newsResponse = new NewsResponseModel
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                CreatedBy = news.CreatedBy,
                CreatedDate = news.CreatedDate
            };

            _repositoryManagerMock.Setup(repo => repo.News.GetNews(id, false)).ReturnsAsync(news);
            _mapperMock.Setup(mapper => mapper.Map<NewsResponseModel>(news)).Returns(newsResponse);

            // Act
            var result = await _newsServiceMock.GetNewsById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(news.Id, result.Id);
            Assert.Equal(news.Title, result.Title);
            Assert.Equal(news.Content, result.Content);
            Assert.Equal(news.CreatedBy, result.CreatedBy);
            Assert.Equal(news.CreatedDate, result.CreatedDate);
            _repositoryManagerMock.Verify(repo => repo.News.GetNews(id, false), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<NewsResponseModel>(news), Times.Once);
        }

        [Fact]
        public async Task GetNewsById_ShouldThrowException_WhenNewsNotFound()
        {
            // Arrange
            var id = Guid.NewGuid();
            _repositoryManagerMock.Setup(repo => repo.News.GetNews(id, false)).ReturnsAsync((News)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<BadRequestException>(() => _newsServiceMock.GetNewsById(id));
            Assert.Equal("Can't found news with id " + id, exception.Message);
            _repositoryManagerMock.Verify(repo => repo.News.GetNews(id, false), Times.Once);
        }
    }
}
