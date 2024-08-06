using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Service;
using Shared.DataTransferObjects.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LMS_UnitTest.NewsTest
{
    public class UpdateNewsTest
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly NewsService _newsServiceMock;

        public UpdateNewsTest()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _newsServiceMock = new NewsService(
                _repositoryManagerMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task UpdateNews_ShouldThrowException_WhenNewsDoesNotExist()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new UpdateNewsRequestModel
            {
                Title = "Updated Title",
                Content = "Updated Content",
                FileKey = new List<string> { "file1", "file2" }
            };

            _repositoryManagerMock.Setup(repo => repo.News.GetNews(id, true)).ReturnsAsync((News)null);

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() => _newsServiceMock.UpdateNews(id, model));
        }

        [Fact]
        public async Task UpdateNews_ShouldUpdateNews_WhenModelIsValid()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new UpdateNewsRequestModel
            {
                Title = "Updated Title",
                Content = "Updated Content",
                FileKey = new List<string> { "file1", "file2" }
            };

            var existingNews = new News
            {
                Id = id,
                Title = "Old Title",
                Content = "Old Content"
            };

            _repositoryManagerMock.Setup(repo => repo.News.GetNews(id, true)).ReturnsAsync(existingNews);
            _repositoryManagerMock.Setup(repo => repo.NewsFile.GetByCondition(f => f.NewsID.Equals(id), false)).Returns(new List<NewsFile>().AsQueryable());
            _repositoryManagerMock.Setup(repo => repo.Save()).Returns(Task.CompletedTask);
            _mapperMock.Setup(mapper => mapper.Map(model, existingNews));

            // Act
            await _newsServiceMock.UpdateNews(id, model);

            // Assert
            _repositoryManagerMock.Verify(repo => repo.News.GetNews(id, true), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map(model, existingNews), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.NewsFile.DeleteRange(It.IsAny<IEnumerable<NewsFile>>()), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.NewsFile.AddRange(It.IsAny<IEnumerable<NewsFile>>()), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public async Task UpdateNews_ShouldDeleteExistingFiles_WhenFileKeysProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new UpdateNewsRequestModel
            {
                Title = "Updated Title",
                Content = "Updated Content",
                FileKey = new List<string> { "file1", "file2" }
            };

            var existingNews = new News
            {
                Id = id,
                Title = "Old Title",
                Content = "Old Content"
            };

            var existingFiles = GetQueryableMockDbSet<NewsFile>(new List<NewsFile>
            {
                new NewsFile { Id = Guid.NewGuid(), NewsID = id, FileKey = "oldFile1" },
                new NewsFile { Id = Guid.NewGuid(), NewsID = id, FileKey = "oldFile2" }
            });

            var newFiles = model.FileKey.Select(fileKey => new NewsFile
            {
                Id = Guid.NewGuid(),
                NewsID = id,
                FileKey = fileKey
            }).ToList();

            _repositoryManagerMock.Setup(repo => repo.News.GetNews(id, true)).ReturnsAsync(existingNews);
            _repositoryManagerMock.Setup(repo => repo.NewsFile.GetByCondition(f => f.NewsID.Equals(id), false)).Returns(existingFiles);
            _repositoryManagerMock.Setup(repo => repo.NewsFile.DeleteRange(existingFiles));
            _repositoryManagerMock.Setup(repo => repo.NewsFile.AddRange(It.IsAny<IEnumerable<NewsFile>>()));
            _repositoryManagerMock.Setup(repo => repo.Save()).Returns(Task.CompletedTask);
            _mapperMock.Setup(mapper => mapper.Map(model, existingNews));
            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<NewsFile>>(It.IsAny<IEnumerable<NewsFileRequestModel>>())).Returns(newFiles);

            // Act
            await _newsServiceMock.UpdateNews(id, model);

            // Assert
            _repositoryManagerMock.Verify(repo => repo.News.GetNews(id, true), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.NewsFile.DeleteRange(existingFiles), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.NewsFile.AddRange(It.IsAny<IEnumerable<NewsFile>>()), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public async Task UpdateNews_ShouldNotDeleteExistingFiles_WhenFileKeysNotProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new UpdateNewsRequestModel
            {
                Title = "Updated Title",
                Content = "Updated Content",
                FileKey = null
            };

            var existingNews = new News
            {
                Id = id,
                Title = "Old Title",
                Content = "Old Content"
            };

            _repositoryManagerMock.Setup(repo => repo.News.GetNews(id, true)).ReturnsAsync(existingNews);
            _repositoryManagerMock.Setup(repo => repo.Save()).Returns(Task.CompletedTask);
            _mapperMock.Setup(mapper => mapper.Map(model, existingNews));

            // Act
            await _newsServiceMock.UpdateNews(id, model);

            // Assert
            _repositoryManagerMock.Verify(repo => repo.News.GetNews(id, true), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map(model, existingNews), Times.Once);
            _repositoryManagerMock.Verify(repo => repo.NewsFile.DeleteRange(It.IsAny<IEnumerable<NewsFile>>()), Times.Never);
            _repositoryManagerMock.Verify(repo => repo.NewsFile.AddRange(It.IsAny<IEnumerable<NewsFile>>()), Times.Never);
            _repositoryManagerMock.Verify(repo => repo.Save(), Times.Once);
        }

        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }
    }
}
