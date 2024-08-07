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

namespace LMS_UnitTest.TaskListTest
{
    public class MoveTaskListInProjectTest
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly TaskListService _taskListServiceMock;

        public MoveTaskListInProjectTest()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _taskListServiceMock = new TaskListService(
                _repositoryManagerMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task GetTaskListForPatch_ShouldReturnTaskListToPatchAndEntity()
        {
            var projectId = Guid.NewGuid();
            var taskListId = Guid.NewGuid();
            var project = new Project { Id = projectId, TaskLists = new List<TaskList> { new TaskList { Id = taskListId } } };
            var taskList = new TaskList { Id = taskListId };
            var taskListUpdateRequestModel = new TaskListUpdateRequestModel();

            var mockProject = MockQueryableExtensions.CreateMockQueryable((new List<Project> { project }).AsQueryable());
            var mockTaskList = MockQueryableExtensions.CreateMockQueryable((new List<TaskList> { taskList }).AsQueryable());

            _repositoryManagerMock.Setup(r => r.Project.GetByCondition(It.IsAny<Expression<Func<Project, bool>>>(), false))
                .Returns(mockProject.Object);

            _repositoryManagerMock.Setup(r => r.TaskList.GetByCondition(It.IsAny<Expression<Func<TaskList, bool>>>(), true))
                .Returns(mockTaskList.Object);

            _mapperMock.Setup(m => m.Map<TaskListUpdateRequestModel>(It.IsAny<TaskList>())).Returns(taskListUpdateRequestModel);

            var result = await _taskListServiceMock.GetTaskListForPatch(projectId, taskListId);

            Assert.Equal(taskListUpdateRequestModel, result.taskListToPatch);
            Assert.Equal(taskList, result.taskListEntity);
        }

        [Fact]
        public async Task GetTaskListForPatch_ShouldThrowBadRequestException_WhenProjectNotFound()
        {
            var projectId = Guid.NewGuid();
            var taskListId = Guid.NewGuid();

            _repositoryManagerMock.Setup(r => r.Project.GetByCondition(It.IsAny<Expression<Func<Project, bool>>>(), false))
                .Returns(Enumerable.Empty<Project>().AsQueryable());

            await Assert.ThrowsAsync<BadRequestException>(() => _taskListServiceMock.GetTaskListForPatch(projectId, taskListId));
        }

        [Fact]
        public async Task GetTaskListForPatch_ShouldThrowBadRequestException_WhenTaskListNotInProject()
        {
            var projectId = Guid.NewGuid();
            var taskListId = Guid.NewGuid();
            var project = new Project { Id = projectId, TaskLists = new List<TaskList>() };

            _repositoryManagerMock.Setup(r => r.Project.GetByCondition(It.IsAny<Expression<Func<Project, bool>>>(), false))
                .Returns((new List<Project> { project }).AsQueryable());

            await Assert.ThrowsAsync<BadRequestException>(() => _taskListServiceMock.GetTaskListForPatch(projectId, taskListId));
        }

        [Fact]
        public async Task SaveChangesForPatch_ShouldUpdateTaskListOrder()
        {
            var taskListId = Guid.NewGuid();
            var projectId = Guid.NewGuid();
            var userId = "user123";
            var taskListToPatch = new TaskListUpdateRequestModel { Order = 2 };
            var taskListEntity = new TaskList { Id = taskListId, ProjectId = projectId, Order = 1 };
            var taskLists = new List<TaskList>
        {
            new TaskList { Id = taskListId, ProjectId = projectId, Order = 1 },
            new TaskList { Id = Guid.NewGuid(), ProjectId = projectId, Order = 2 }
        };

            _repositoryManagerMock.Setup(r => r.TaskList.GetByCondition(It.IsAny<Expression<Func<TaskList, bool>>>(), true))
                .Returns(taskLists.AsQueryable());

            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), false))
                .Returns((new List<Member> { new Member { UserId = userId, ProjectId = projectId } }).AsQueryable());

            _mapperMock.Setup(m => m.Map(It.IsAny<TaskListUpdateRequestModel>(), It.IsAny<TaskList>())).Returns(taskListEntity);

            await _taskListServiceMock.SaveChangesForPatch(taskListToPatch, taskListEntity, userId);

            _repositoryManagerMock.Verify(r => r.Save(), Times.Once);
            Assert.Equal(2, taskListEntity.Order);
        }

        [Fact]
        public async Task SaveChangesForPatch_ShouldThrowBadRequestException_WhenInvalidOrder()
        {
            var taskListId = Guid.NewGuid();
            var projectId = Guid.NewGuid();
            var userId = "user123";
            var taskListToPatch = new TaskListUpdateRequestModel { Order = 3 };
            var taskListEntity = new TaskList { Id = taskListId, ProjectId = projectId, Order = 1 };
            var taskLists = new List<TaskList>
        {
            new TaskList { Id = taskListId, ProjectId = projectId, Order = 1 },
            new TaskList { Id = Guid.NewGuid(), ProjectId = projectId, Order = 2 }
        };
            _repositoryManagerMock.Setup(r => r.TaskList.GetByCondition(It.IsAny<Expression<Func<TaskList, bool>>>(), true))
                .Returns(taskLists.AsQueryable());

            await Assert.ThrowsAsync<BadRequestException>(() => _taskListServiceMock.SaveChangesForPatch(taskListToPatch, taskListEntity, userId));
        }

        [Fact]
        public async Task IsMemberInProject_ShouldReturnTrue_WhenMemberExists()
        {
            var projectId = Guid.NewGuid();
            var userId = "user123";
            var member = new Member { UserId = userId, ProjectId = projectId };

            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), false))
                .Returns((new List<Member> { member }).AsQueryable());

            var result = await _taskListServiceMock.IsMemberInProject(projectId, userId);

            Assert.True(result);
        }

        [Fact]
        public async Task IsMemberInProject_ShouldReturnFalse_WhenMemberNotExists()
        {
            var projectId = Guid.NewGuid();
            var userId = "user123";

            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), false))
                .Returns(Enumerable.Empty<Member>().AsQueryable());

            var result = await _taskListServiceMock.IsMemberInProject(projectId, userId);

            Assert.False(result);
        }

        [Fact]
        public async Task IsMemberInProject_ShouldThrowBadRequestException_WhenMemberNotFound()
        {
            var projectId = Guid.NewGuid();
            var userId = "user123";

            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), false))
                .Returns(Enumerable.Empty<Member>().AsQueryable());

            await Assert.ThrowsAsync<BadRequestException>(() => _taskListServiceMock.IsMemberInProject(projectId, userId));
        }
    }
}
