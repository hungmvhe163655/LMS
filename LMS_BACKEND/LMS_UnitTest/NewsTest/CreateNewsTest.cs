using AutoMapper;
using Contracts.Interfaces;
using Entities.Models;
using Moq;
using Service;
using Shared.DataTransferObjects.RequestDTO;
using Xunit;

namespace LMS_UnitTest.NewsTest
{

    public static class CreateNewsTest
    {
        [Fact]
        public static async Task CreateNewsWithAllFields()
        {
            //Arrange

            var mockManager = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();

            var userId = Guid.NewGuid();

            var newsData = new CreateNewsRequestModel()
            {
                Content = "testing",
                Title = "test",
                FileKey = new List<string>
                    {
                        "1123",
                        "12233"
                    }
            };

            var service = new NewsService(mockManager.Object, mockMapper.Object);

            //Act
            var response = await service.CreateNewsAsync(userId.ToString(), newsData);

            //Assert
            Assert.NotNull(response);
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
