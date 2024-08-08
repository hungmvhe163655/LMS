using AutoMapper;
using Contracts.Interfaces;
using Entities.Models;
using LMS_UnitTest.Helper;
using Moq;
using Service;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LMS_UnitTest.ProjectTest
{
    public class GetJoinRequestsTest
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ProjectService _projectService;

        public GetJoinRequestsTest()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _projectService = new ProjectService(
                _repositoryManagerMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task GetJoinRequest_ShouldReturnJoinRequests_WhenProjectHasJoinRequests()
        {
            // Arrange
            var projectId = Guid.NewGuid();
            var members = new List<Member>
            {
                new Member { UserId = "1", ProjectId = projectId, IsValidTeamMember = false, User = new Account { Id = "1", FullName = "John Doe", CreatedDate = DateTime.Now } },
                new Member { UserId = "2", ProjectId = projectId, IsValidTeamMember = false, User = new Account { Id = "2", FullName = "Jane Doe", CreatedDate = DateTime.Now } }
            }.AsQueryable();

            var mockQueryable = MockQueryableExtensions.CreateMockQueryable(members);

            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), false))
                .Returns(mockQueryable.Object);

            _mapperMock.Setup(m => m.Map<List<AccountRequestJoinResponseModel>>(It.IsAny<List<Account>>()))
                .Returns(new List<AccountRequestJoinResponseModel>
                {
                new AccountRequestJoinResponseModel { Id = "1", FullName = "John Doe", CreatedDate = DateTime.Now },
                new AccountRequestJoinResponseModel { Id = "2", FullName = "Jane Doe", CreatedDate = DateTime.Now }
                });

            // Act
            var result = await _projectService.GetJoinRequest(projectId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetJoinRequest_ShouldReturnEmpty_WhenProjectHasNoJoinRequests()
        {
            // Arrange
            var projectId = Guid.NewGuid();
            var members = new List<Member>().AsQueryable();

            var mockQueryable = MockQueryableExtensions.CreateMockQueryable(members);

            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), false))
                .Returns(mockQueryable.Object);

            _mapperMock.Setup(m => m.Map<List<AccountRequestJoinResponseModel>>(It.IsAny<List<Account>>()))
                .Returns(new List<AccountRequestJoinResponseModel>());

            // Act
            var result = await _projectService.GetJoinRequest(projectId);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetJoinRequest_ShouldReturnRequests_WhenJoinRequestsIncludeUsers()
        {
            // Arrange
            var projectId = Guid.NewGuid();
            var members = new List<Member>
            {
                new Member { UserId = "1", ProjectId = projectId, IsValidTeamMember = false, User = new Account { Id = "1", FullName = "John Doe", CreatedDate = DateTime.Now } },
                new Member { UserId = "2", ProjectId = projectId, IsValidTeamMember = false, User = new Account { Id = "2", FullName = "Jane Doe", CreatedDate = DateTime.Now } }
            }.AsQueryable();

            var mockQueryable = MockQueryableExtensions.CreateMockQueryable(members);

            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), false))
                .Returns(mockQueryable.Object);

            _mapperMock.Setup(m => m.Map<List<AccountRequestJoinResponseModel>>(It.IsAny<List<Account>>()))
                .Returns(new List<AccountRequestJoinResponseModel>
                {
                new AccountRequestJoinResponseModel { Id = "1", FullName = "John Doe", CreatedDate = DateTime.Now },
                new AccountRequestJoinResponseModel { Id = "2", FullName = "Jane Doe", CreatedDate = DateTime.Now }
                });

            // Act
            var result = await _projectService.GetJoinRequest(projectId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetJoinRequest_ShouldReturnEmpty_WhenJoinRequestsDoNotIncludeUsers()
        {
            // Arrange
            var projectId = Guid.NewGuid();
            var members = new List<Member>
            {
                new Member { UserId = "1", ProjectId = projectId, IsValidTeamMember = false, User = null },
                new Member { UserId = "2", ProjectId = projectId, IsValidTeamMember = false, User = null }
            };

            var mockQueryable = MockQueryableExtensions.CreateMockQueryable(members.AsQueryable());

            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), false))
                .Returns(mockQueryable.Object);

            _mapperMock.Setup(m => m.Map<List<AccountRequestJoinResponseModel>>(It.IsAny<List<Account>>()))
                .Returns(new List<AccountRequestJoinResponseModel>());

            // Act
            var result = await _projectService.GetJoinRequest(projectId);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
