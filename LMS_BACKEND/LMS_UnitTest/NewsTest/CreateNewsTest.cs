using AutoMapper;
using Contracts.Interfaces;
using Entities.Models;
using Moq;
using Service;
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

            _repositoryManagerMock.Setup(r => r.News.CreateAsync(It.IsAny<News>())).Returns(Task.CompletedTask);
            _repositoryManagerMock.Setup(r => r.NewsFile.AddRange(It.IsAny<IEnumerable<NewsFile>>())).Returns(Task.CompletedTask);
            _repositoryManagerMock.Setup(r => r.Save()).Returns(Task.CompletedTask);
            _mapperMock.Setup(m => m.Map<NewsReponseModel>(It.IsAny<News>())).Returns((News source) => new NewsReponseModel { Title = source.Title });

        }

        [Fact]
        public async Task CreateNews_WithValidInput_ReturnsNewsResponseModel()
        {
            //Arrange
            var userId = "User123";

            var createRequest = new CreateNewsRequestModel
            {
                Content = "testing",
                Title = "test",
                FileKey = new List<string> { "FileKey123" }
            };

            _mapperMock.Setup(m => m.Map<IEnumerable<NewsFile>>(It.IsAny<IEnumerable<NewsFileRequestModel>>()))
                       .Returns((IEnumerable<NewsFileRequestModel> source) =>
                       {
                           return source.Select(x => new NewsFile
                           {
                               Id = x.Id,
                               NewsID = x.NewsID,
                               FileKey = x.FileKey
                           }).ToList();
                       });
            //Act
            var result = await _newsServiceMock.CreateNewsAsync(userId, createRequest);

            //Assert
            _repositoryManagerMock.Verify(r => r.News.CreateAsync(It.IsAny<News>()), Times.Once);
            _repositoryManagerMock.Verify(r => r.NewsFile.AddRange(It.IsAny<IEnumerable<NewsFile>>()), Times.Once);
            _repositoryManagerMock.Verify(r => r.Save(), Times.Once);
            _mapperMock.Verify(m => m.Map<NewsReponseModel>(It.IsAny<News>()), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(createRequest.Content, result.Content);
        }
        //[Fact]
        //public static async Task CreateNewsWithRequiredFields()
        //{
        //    //Arrange

        //    var mockManager = new Mock<IRepositoryManager>();
        //    var mockMapper = new Mock<IMapper>();

        //    var userId = Guid.NewGuid();

        //    var newsData = new CreateNewsRequestModel()
        //    {
        //        Title = "test",
        //    };

        //    var service = new NewsService(mockManager.Object, mockMapper.Object);

        //    //Act
        //    var response = await service.CreateNewsAsync( userId.ToString(), newsData);

        //    //Assert
        //    Assert.NotNull(response);
        //}
    }
}
