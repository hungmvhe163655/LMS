using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using LMS_UnitTest.Helper;
using Moq;
using Service;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LMS_UnitTest.ProjectTest
{
    public class UpdateProjectTest
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ProjectService _projectServiceMock;

        public UpdateProjectTest()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _projectServiceMock = new ProjectService(
                _repositoryManagerMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task UpdateProject_ShouldUpdateProject_WhenDataIsValid()
        {
            var projectId = Guid.NewGuid();
            var userId = "user123";
            var model = new ProjectUpdateRequestModel
            {
                Name = "Updated Project",
                Description = "Updated Description",
                MaxMember = 10,
                IsRecruiting = true,
                LeaderId = "newLeaderId"
            };

            var project = new Project { Id = projectId };
            var members = new List<Member>
        {
            new Member { UserId = "user123", ProjectId = projectId, IsLeader = true },
            new Member { UserId = "newLeaderId", ProjectId = projectId, IsLeader = false }
        };

            _repositoryManagerMock.Setup(r => r.Project.GetByCondition(It.IsAny<Expression<Func<Project, bool>>>(), true))
                .Returns((new List<Project> { project }).AsQueryable());
            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), true))
                .Returns((members).AsQueryable());

            await _projectServiceMock.UpdateProject(model, projectId, userId);

            _repositoryManagerMock.Verify(r => r.Save(), Times.Once);
            _mapperMock.Verify(m => m.Map(model, project), Times.Once);
        }

        [Fact]
        public async Task UpdateProject_ShouldThrowBadRequestException_WhenProjectIsNull()
        {
            var projectId = Guid.NewGuid();
            var userId = "user123";
            var model = new ProjectUpdateRequestModel
            {
                Name = "Updated Project",
                Description = "Updated Description",
                MaxMember = 10,
                IsRecruiting = true,
                LeaderId = "newLeaderId"
            };

            _repositoryManagerMock.Setup(r => r.Project.GetByCondition(It.IsAny<Expression<Func<Project, bool>>>(), true))
                .Returns(Enumerable.Empty<Project>().AsQueryable());

            await Assert.ThrowsAsync<BadRequestException>(() => _projectServiceMock.UpdateProject(model, projectId, userId));
        }

        [Fact]
        public async Task UpdateProject_ShouldThrowBadRequestException_WhenUserIsNotLeader()
        {
            var projectId = Guid.NewGuid();
            var userId = "user123";
            var model = new ProjectUpdateRequestModel
            {
                Name = "Updated Project",
                Description = "Updated Description",
                MaxMember = 10,
                IsRecruiting = true,
                LeaderId = "newLeaderId"
            };

            var project = new Project { Id = projectId };
            var members = new List<Member>
        {
            new Member { UserId = "otherUser", ProjectId = projectId, IsLeader = true }
        };

            _repositoryManagerMock.Setup(r => r.Project.GetByCondition(It.IsAny<Expression<Func<Project, bool>>>(), true))
                .Returns((new List<Project> { project }).AsQueryable());
            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), true))
                .Returns((members).AsQueryable());

            await Assert.ThrowsAsync<BadRequestException>(() => _projectServiceMock.UpdateProject(model, projectId, userId));
        }

        [Fact]
        public async Task UpdateProject_ShouldThrowBadRequestException_WhenNoMembersInProject()
        {
            var projectId = Guid.NewGuid();
            var userId = "user123";
            var model = new ProjectUpdateRequestModel
            {
                Name = "Updated Project",
                Description = "Updated Description",
                MaxMember = 10,
                IsRecruiting = true,
                LeaderId = "newLeaderId"
            };

            var project = new Project { Id = projectId };

            var mockProject = MockQueryableExtensions.CreateMockQueryable((new List<Project> { project }).AsQueryable());
            var mockMember = MockQueryableExtensions.CreateMockQueryable(Enumerable.Empty<Member>().AsQueryable());

            _repositoryManagerMock.Setup(r => r.Project.GetByCondition(It.IsAny<Expression<Func<Project, bool>>>(), true))
                .Returns(mockProject.Object);
            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), true))
                .Returns(mockMember.Object);

            await Assert.ThrowsAsync<BadRequestException>(() => _projectServiceMock.UpdateProject(model, projectId, userId));
        }

        [Fact]
        public async Task UpdateProject_ShouldThrowBadRequestException_WhenLeaderIdIsSameAsUserId()
        {
            var projectId = Guid.NewGuid();
            var userId = "user123";
            var model = new ProjectUpdateRequestModel
            {
                Name = "Updated Project",
                Description = "Updated Description",
                MaxMember = 10,
                IsRecruiting = true,
                LeaderId = userId
            };

            await Assert.ThrowsAsync<BadRequestException>(() => _projectServiceMock.UpdateProject(model, projectId, userId));
        }

        [Fact]
        public async Task UpdateProject_ShouldUpdateLeader_WhenNewLeaderIsSpecified()
        {
            var projectId = Guid.NewGuid();
            var userId = "user123";
            var newLeaderId = "newLeaderId";
            var model = new ProjectUpdateRequestModel
            {
                Name = "Updated Project",
                Description = "Updated Description",
                MaxMember = 10,
                IsRecruiting = true,
                LeaderId = newLeaderId
            };

            var project = new Project { Id = projectId };
            var members = new List<Member>
        {
            new Member { UserId = userId, ProjectId = projectId, IsLeader = true },
            new Member { UserId = newLeaderId, ProjectId = projectId, IsLeader = false }
        };

            _repositoryManagerMock.Setup(r => r.Project.GetByCondition(It.IsAny<Expression<Func<Project, bool>>>(), true))
                .Returns((new List<Project> { project }).AsQueryable());
            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), true))
                .Returns((members).AsQueryable());

            await _projectServiceMock.UpdateProject(model, projectId, userId);

            Assert.False(members.First(m => m.UserId == userId).IsLeader);
            Assert.True(members.First(m => m.UserId == newLeaderId).IsLeader);
        }
    }
}
