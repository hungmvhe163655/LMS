using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Moq;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LMS_UnitTest.TaskTest
{
    public class AssignUserToTaskTest
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly TaskService _taskService;

        public AssignUserToTaskTest()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();

            _mapperMock = new Mock<IMapper>();

            _taskService = new TaskService(
                _repositoryManagerMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task AssignUserToTask_ShouldAssignUser_WhenValidInput()
        {
            var taskId = Guid.NewGuid();
            var userId = "user123";
            var editorId = "editor123";
            var projectId = Guid.NewGuid();
            var task = new Tasks { Id = taskId, ProjectId = projectId };
            var editor = new Member { UserId = editorId, ProjectId = projectId, IsLeader = true };
            var worker = new Member { UserId = userId, ProjectId = projectId, User = new Account { Id = userId } };

            _repositoryManagerMock.Setup(r => r.Task.GetTaskWithId(It.IsAny<Guid>(), false))
                .Returns((new List<Tasks> { task }).AsQueryable());

            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), false))
                .Returns((new List<Member> { editor, worker }).AsQueryable());

            await _taskService.AssignUserToTask(taskId, userId, editorId);

            _repositoryManagerMock.Verify(r => r.Task.UpdateTask(task), Times.Once);
            _repositoryManagerMock.Verify(r => r.Save(), Times.Once);
            Assert.Equal(userId, task.AssignedTo);
        }

        [Fact]
        public async Task AssignUserToTask_ShouldThrowBadRequestException_WhenTaskNotFound()
        {
            var taskId = Guid.NewGuid();
            var userId = "user123";
            var editorId = "editor123";

            _repositoryManagerMock.Setup(r => r.Task.GetTaskWithId(It.IsAny<Guid>(), false))
                .Returns(Enumerable.Empty<Tasks>().AsQueryable());

            await Assert.ThrowsAsync<BadRequestException>(() => _taskService.AssignUserToTask(taskId, userId, editorId));
        }

        [Fact]
        public async Task AssignUserToTask_ShouldThrowBadRequestException_WhenEditorNotLeader()
        {
            var taskId = Guid.NewGuid();
            var userId = "user123";
            var editorId = "editor123";
            var projectId = Guid.NewGuid();
            var task = new Tasks { Id = taskId, ProjectId = projectId };
            var editor = new Member { UserId = editorId, ProjectId = projectId, IsLeader = false };

            _repositoryManagerMock.Setup(r => r.Task.GetTaskWithId(It.IsAny<Guid>(), false))
                .Returns((new List<Tasks> { task }).AsQueryable());

            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), false))
                .Returns((new List<Member> { editor }).AsQueryable());

            await Assert.ThrowsAsync<BadRequestException>(() => _taskService.AssignUserToTask(taskId, userId, editorId));
        }

        [Fact]
        public async Task AssignUserToTask_ShouldThrowBadRequestException_WhenWorkerNotFound()
        {
            var taskId = Guid.NewGuid();
            var userId = "user123";
            var editorId = "editor123";
            var projectId = Guid.NewGuid();
            var task = new Tasks { Id = taskId, ProjectId = projectId };
            var editor = new Member { UserId = editorId, ProjectId = projectId, IsLeader = true };

            _repositoryManagerMock.Setup(r => r.Task.GetTaskWithId(It.IsAny<Guid>(), false))
                .Returns((new List<Tasks> { task }).AsQueryable());

            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), false))
                .Returns((new List<Member> { editor }).AsQueryable());

            await Assert.ThrowsAsync<BadRequestException>(() => _taskService.AssignUserToTask(taskId, userId, editorId));
        }


    }
}
