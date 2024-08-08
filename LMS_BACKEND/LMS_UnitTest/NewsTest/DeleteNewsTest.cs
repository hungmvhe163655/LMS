using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Moq;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LMS_UnitTest.NewsTest
{
    public class DeleteNewsTest
    {

        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly NewsService _newsServiceMock;

        public DeleteNewsTest()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _newsServiceMock = new NewsService(
                _repositoryManagerMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task DeleteNews_ShouldDeleteNewsAndFiles_WhenIdIsValid()
        {
            // Arrange
            var id = Guid.NewGuid();
            var news = new News { Id = id };
            var newsFiles = new List<NewsFile>
        {
            new NewsFile { Id = Guid.NewGuid(), NewsID = id },
            new NewsFile { Id = Guid.NewGuid(), NewsID = id }
        };

            _repositoryManagerMock.Setup(repo => repo.News.GetNews(id, false)).ReturnsAsync(news);
            _repositoryManagerMock.Setup(repo => repo.NewsFile.GetByConditionAsync(n => n.NewsID.Equals(id), false)).ReturnsAsync(newsFiles);
            _repositoryManagerMock.Setup(repo => repo.Save()).Returns(Task.CompletedTask);

            // Act
            await _newsServiceMock.DeleteNews(id);

            // Assert
            _repositoryManagerMock.Verify(repo => repo.News.GetNews(id, false), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.NewsFile.GetByConditionAsync(n => n.NewsID.Equals(id), false), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.NewsFile.DeleteRange(newsFiles), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.News.Delete(news), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public async Task DeleteNews_ShouldThrowException_WhenNewsNotFound()
        {
            // Arrange
            var id = Guid.NewGuid();
            _repositoryManagerMock.Setup(repo => repo.News.GetNews(id, false)).ReturnsAsync((News)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<BadRequestException>(() => _newsServiceMock.DeleteNews(id));
            Assert.Equal("News with id: " + id + " doesn't exist", exception.Message);
            _repositoryManagerMock.Verify(repo => repo.News.GetNews(id, false), Times.Once);
        }

        [Fact]
        public async Task DeleteNews_ShouldDeleteNewsWithoutFiles_WhenNoFilesExist()
        {
            // Arrange
            var id = Guid.NewGuid();
            var news = new News { Id = id };
            var emptyNewsFiles = new List<NewsFile>();

            _repositoryManagerMock.Setup(repo => repo.News.GetNews(id, false)).ReturnsAsync(news);
            _repositoryManagerMock.Setup(repo => repo.NewsFile.GetByConditionAsync(n => n.NewsID.Equals(id), false)).ReturnsAsync(emptyNewsFiles);
            _repositoryManagerMock.Setup(repo => repo.Save()).Returns(Task.CompletedTask);

            // Act
            await _newsServiceMock.DeleteNews(id);

            // Assert
            _repositoryManagerMock.Verify(repo => repo.News.GetNews(id, false), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.NewsFile.GetByConditionAsync(n => n.NewsID.Equals(id), false), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.NewsFile.DeleteRange(It.IsAny<IEnumerable<NewsFile>>()), Times.Never);
            _repositoryManagerMock.Verify(repo => repo.News.Delete(news), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.Save(), Times.Once);
        }
    }
}
