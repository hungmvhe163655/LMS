using AutoMapper;
using Contracts.Interfaces;
using Entities.Models;
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
    public class ValidateJoinRequestTest
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ProjectService _projectServiceMock;

        public ValidateJoinRequestTest()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _projectServiceMock = new ProjectService(
                _repositoryManagerMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task ValidateJoinRequest_ShouldValidateAndAcceptJoinRequests()
        {
            var projectId = Guid.NewGuid();
            var userId = "user123";
            var listModel = new List<UpdateStudentJoinRequestModel>
        {
            new UpdateStudentJoinRequestModel { Id = userId, Accepted = true, ProjectID = projectId }
        };

            var member = new Member { UserId = userId, ProjectId = projectId, IsValidTeamMember = false };

            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), false))
                .Returns((new List<Member> { member }).AsQueryable());

            await _projectServiceMock.ValidateJoinRequest(listModel, projectId);

            _repositoryManagerMock.Verify(r => r.Save(), Times.Once);
            Assert.True(member.IsValidTeamMember);
        }

        [Fact]
        public async Task ValidateJoinRequest_ShouldValidateAndRejectJoinRequests()
        {
            var projectId = Guid.NewGuid();
            var userId = "user123";
            var listModel = new List<UpdateStudentJoinRequestModel>
        {
            new UpdateStudentJoinRequestModel { Id = userId, Accepted = false, ProjectID = projectId }
        };

            var member = new Member { UserId = userId, ProjectId = projectId, IsValidTeamMember = false };

            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), false))
                .Returns((new List<Member> { member }).AsQueryable());

            await _projectServiceMock.ValidateJoinRequest(listModel, projectId);

            _repositoryManagerMock.Verify(r => r.Member.Delete(member), Times.Once);
            _repositoryManagerMock.Verify(r => r.Save(), Times.Once);
        }

        [Fact]
        public async Task ValidateJoinRequest_ShouldThrowException_WhenMemberNotFound()
        {
            var projectId = Guid.NewGuid();
            var listModel = new List<UpdateStudentJoinRequestModel>
        {
            new UpdateStudentJoinRequestModel { Id = "user123", Accepted = true, ProjectID = projectId }
        };

            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), false))
            .Returns(Enumerable.Empty<Member>().AsQueryable());

            await Assert.ThrowsAsync<InvalidOperationException>(() => _projectServiceMock.ValidateJoinRequest(listModel, projectId));
        }

        [Fact]
        public async Task ValidateJoinRequest_ShouldThrowException_WhenDatabaseLogicFails()
        {
            var projectId = Guid.NewGuid();
            var userId = "user123";
            var listModel = new List<UpdateStudentJoinRequestModel>
        {
            new UpdateStudentJoinRequestModel { Id = userId, Accepted = true, ProjectID = projectId }
        };

            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), false))
            .Throws<Exception>();

            await Assert.ThrowsAsync<Exception>(() => _projectServiceMock.ValidateJoinRequest(listModel, projectId));
        }
    }
}
