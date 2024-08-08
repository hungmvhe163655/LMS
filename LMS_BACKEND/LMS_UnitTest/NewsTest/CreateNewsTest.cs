using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Moq;
using Service;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using Xunit;

namespace LMS_UnitTest.NewsTest
{

    public class CreateNewsTest
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;

        private readonly Mock<IMapper> _mapperMock;

        private readonly NewsService _newsServiceMock;

        public CreateNewsTest() 
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _newsServiceMock = new NewsService(
                _repositoryManagerMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task CreateNewsAsync_ShouldThrowException_WhenTitleIsNull()
        {
            // Arrange
            var model = new CreateNewsRequestModel
            {
                Title = null,
                Content = "Sample content",
                FileKey = new List<string> { "file1", "file2" }
            };

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() => _newsServiceMock.CreateNewsAsync("userId", model));
        }

        [Fact]
        public async Task CreateNewsAsync_ShouldThrowException_WhenTitleIsEmpty()
        {
            // Arrange
            var model = new CreateNewsRequestModel
            {
                Title = "",
                Content = "Sample content",
                FileKey = new List<string> { "file1", "file2" }
            };

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() => _newsServiceMock.CreateNewsAsync("userId", model));
        }

        [Fact]
        public async Task CreateNewsAsync_ShouldCreateNews_WhenTitleIsProvided()
        {
            // Arrange
            var model = new CreateNewsRequestModel
            {
                Title = "Sample Title",
                Content = "Sample content",
                FileKey = new List<string> { "file1", "file2" }
            };

            var news = new News
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Content = model.Content ?? "",
                CreatedBy = "userId",
                CreatedDate = DateTime.Now
            };

            _repositoryManagerMock.Setup(repo => repo.News.CreateAsync(It.IsAny<News>())).Returns(Task.CompletedTask);
            _repositoryManagerMock.Setup(repo => repo.NewsFile.AddRange(It.IsAny<IEnumerable<NewsFile>>())).Returns(Task.CompletedTask);
            _repositoryManagerMock.Setup(repo => repo.Save()).Returns(Task.CompletedTask);
            _mapperMock.Setup(mapper => mapper.Map<NewsResponseModel>(It.IsAny<News>())).Returns(new NewsResponseModel
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                CreatedBy = news.CreatedBy,
                CreatedDate = news.CreatedDate
            });

            // Act
            var result = await _newsServiceMock.CreateNewsAsync("userId", model);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(model.Title, result.Title);
            Assert.Equal(model.Content, result.Content);
            Assert.Equal("userId", result.CreatedBy);
            Assert.Equal(news.CreatedDate, result.CreatedDate);

            _repositoryManagerMock.Verify(repo => repo.News.CreateAsync(It.IsAny<News>()), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.Save(), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.NewsFile.AddRange(It.IsAny<IEnumerable<NewsFile>>()), Times.Once);
        }

        [Fact]
        public async Task CreateNewsAsync_ShouldCreateNews_WhenFileKeysAreProvided()
        {
            // Arrange
            var model = new CreateNewsRequestModel
            {
                Title = "Sample Title",
                Content = "Sample content",
                FileKey = new List<string> { "file1", "file2" }
            };

            var news = new News
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Content = model.Content ?? "",
                CreatedBy = "userId",
                CreatedDate = DateTime.Now
            };

            var newsFiles = model.FileKey.Select(fileKey => new NewsFileRequestModel
            {
                Id = Guid.NewGuid(),
                NewsID = news.Id,
                FileKey = fileKey
            });

            var mappedNewsFiles = newsFiles.Select(file => new NewsFile
            {
                Id = file.Id,
                NewsID = file.NewsID,
                FileKey = file.FileKey
            });

            _repositoryManagerMock.Setup(repo => repo.News.CreateAsync(It.IsAny<News>())).Returns(Task.CompletedTask);
            _repositoryManagerMock.Setup(repo => repo.NewsFile.AddRange(It.IsAny<IEnumerable<NewsFile>>())).Returns(Task.CompletedTask);
            _repositoryManagerMock.Setup(repo => repo.Save()).Returns(Task.CompletedTask);
            _mapperMock.Setup(mapper => mapper.Map<NewsResponseModel>(It.IsAny<News>())).Returns(new NewsResponseModel
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                CreatedBy = news.CreatedBy,
                CreatedDate = news.CreatedDate
            });
            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<NewsFile>>(It.IsAny<IEnumerable<NewsFileRequestModel>>()))
                .Returns(mappedNewsFiles);

            // Act
            var result = await _newsServiceMock.CreateNewsAsync("userId", model);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(model.Title, result.Title);
            Assert.Equal(model.Content, result.Content);
            Assert.Equal("userId", result.CreatedBy);
            Assert.Equal(news.CreatedDate, result.CreatedDate);

            _repositoryManagerMock.Verify(repo => repo.News.CreateAsync(It.IsAny<News>()), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.Save(), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.NewsFile.AddRange(It.IsAny<IEnumerable<NewsFile>>()), Times.Once);
        }

        [Fact]
        public async Task CreateNewsAsync_ShouldCreateNews_WhenFileKeysAreNotProvided()
        {
            // Arrange
            var model = new CreateNewsRequestModel
            {
                Title = "Sample Title",
                Content = "Sample content",
                FileKey = null
            };

            var news = new News
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Content = model.Content ?? "",
                CreatedBy = "userId",
                CreatedDate = DateTime.Now
            };

            _repositoryManagerMock.Setup(repo => repo.News.CreateAsync(It.IsAny<News>())).Returns(Task.CompletedTask);
            _repositoryManagerMock.Setup(repo => repo.Save()).Returns(Task.CompletedTask);
            _mapperMock.Setup(mapper => mapper.Map<NewsResponseModel>(It.IsAny<News>())).Returns(new NewsResponseModel
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                CreatedBy = news.CreatedBy,
                CreatedDate = news.CreatedDate
            });

            // Act
            var result = await _newsServiceMock.CreateNewsAsync("userId", model);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(model.Title, result.Title);
            Assert.Equal(model.Content, result.Content);
            Assert.Equal("userId", result.CreatedBy);
            Assert.Equal(news.CreatedDate, result.CreatedDate);

            _repositoryManagerMock.Verify(repo => repo.News.CreateAsync(It.IsAny<News>()), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.Save(), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.NewsFile.AddRange(It.IsAny<IEnumerable<NewsFile>>()), Times.Never);
        }
    }
}
