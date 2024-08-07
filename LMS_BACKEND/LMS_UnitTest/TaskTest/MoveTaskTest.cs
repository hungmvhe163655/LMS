using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
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

namespace LMS_UnitTest.TaskTest
{
    public class MoveTaskTest
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly TaskService _taskService;

        public MoveTaskTest()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();

            _mapperMock = new Mock<IMapper>();

            _taskService = new TaskService(
                _repositoryManagerMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task GetTaskForPatch_ShouldReturnTask_WhenValidInput()
        {
            var taskListId = Guid.NewGuid();
            var taskId = Guid.NewGuid();
            var taskList = new TaskList { Id = taskListId, Tasks = new List<Tasks> { new Tasks { Id = taskId } } };
            var task = new Tasks { Id = taskId };
            var taskResponseModel = new TaskResponseModel();

            _repositoryManagerMock.Setup(r => r.TaskList.GetByCondition(It.IsAny<Expression<Func<TaskList, bool>>>(), false))
                .Returns((new List<TaskList> { taskList }).AsQueryable());

            _repositoryManagerMock.Setup(r => r.Task.GetTaskWithId(It.IsAny<Guid>(), true))
                .Returns((new List<Tasks> { task }).AsQueryable());

            _mapperMock.Setup(m => m.Map<TaskResponseModel>(task)).Returns(taskResponseModel);

            var result = await _taskService.GetTaskForPatch(taskListId, taskId);

            Assert.Equal(taskResponseModel, result.taskToPatch);
            Assert.Equal(task, result.taskEntity);
        }

        [Fact]
        public async Task GetTaskForPatch_ShouldThrowBadRequestException_WhenTaskListNotFound()
        {
            var taskListId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            var taskId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            var mockQueryable = MockQueryableExtensions.CreateMockQueryable((new List<TaskList>()).AsQueryable());

            _repositoryManagerMock.Setup(r => r.TaskList.GetByCondition(It.IsAny<Expression<Func<TaskList, bool>>>(), false))
                .Returns(mockQueryable.Object);

            await Assert.ThrowsAsync<BadRequestException>(() => _taskService.GetTaskForPatch(taskListId, taskId));
        }

        [Fact]
        public async Task GetTaskForPatch_ShouldThrowBadRequestException_WhenTaskNotFoundInTaskList()
        {
            var taskListId = Guid.NewGuid();
            var taskId = Guid.NewGuid();
            var taskList = new TaskList { Id = taskListId, Tasks = new List<Tasks>() };

            _repositoryManagerMock.Setup(r => r.TaskList.GetByCondition(It.IsAny<Expression<Func<TaskList, bool>>>(), false))
                .Returns((new List<TaskList> { taskList }).AsQueryable());

            await Assert.ThrowsAsync<BadRequestException>(() => _taskService.GetTaskForPatch(taskListId, taskId));
        }

        [Fact]
        public async Task SaveChangesForPatch_ShouldSaveChanges_WhenValidInput()
        {
            var taskResponseModel = new TaskResponseModel();
            var taskEntity = new Tasks { TaskListId = Guid.NewGuid() };
            var taskListId = taskEntity.TaskListId;
            var tasks = new List<Tasks> { taskEntity };
            var userId = "user123";

            //_mapperMock.Setup(m => m.Map<Tasks>(taskResponseModel, taskEntity)).Returns(taskEntity);

            _repositoryManagerMock.Setup(r => r.Task.GetTasksWithTaskListId(It.IsAny<Guid>(), true))
                .Returns(tasks.AsQueryable);

            _repositoryManagerMock.Setup(r => r.Save()).Returns(Task.CompletedTask);

            _repositoryManagerMock.Setup(r => r.Task.UpdateTask(taskEntity)).Verifiable();

            await _taskService.SaveChangesForPatch(taskResponseModel, taskEntity, userId);

            _repositoryManagerMock.Verify(r => r.Save(), Times.Once);
        }

        [Fact]
        public async Task SaveChangesForPatch_ShouldThrowBadRequestException_WhenTaskListNotAvailable()
        {
            var taskResponseModel = new TaskResponseModel();
            var taskEntity = new Tasks { TaskListId = Guid.NewGuid() };
            var userId = "user123";

            _repositoryManagerMock.Setup(r => r.TaskList.GetByCondition(It.IsAny<Expression<Func<TaskList, bool>>>(), false))
                .Returns(Enumerable.Empty<TaskList>().AsQueryable());

            await Assert.ThrowsAsync<BadRequestException>(() => _taskService.SaveChangesForPatch(taskResponseModel, taskEntity, userId));
        }

        [Fact]
        public async Task SaveChangesForPatch_ShouldThrowBadRequestException_WhenMemberNotInProject()
        {
            var taskResponseModel = new TaskResponseModel();
            var taskEntity = new Tasks { TaskListId = Guid.NewGuid() };
            var userId = "user123";

            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), false))
                .Returns(Enumerable.Empty<Member>().AsQueryable());

            await Assert.ThrowsAsync<BadRequestException>(() => _taskService.SaveChangesForPatch(taskResponseModel, taskEntity, userId));
        }

        [Fact]
        public async Task SaveChangesInTaskListForPatch_ShouldSaveChanges_WhenValidInput()
        {
            var taskResponseModel = new TaskResponseModel { Order = 1 };
            var taskEntity = new Tasks { TaskListId = Guid.NewGuid() };
            var taskListId = taskEntity.TaskListId;
            var tasks = new List<Tasks> { taskEntity };
            var userId = "user123";

            //_mapperMock.Setup(m => m.Map<Tasks>(taskResponseModel, taskEntity)).Returns(taskEntity);

            _repositoryManagerMock.Setup(r => r.Task.GetTasksWithTaskListId(It.IsAny<Guid>(), true))
                .Returns(tasks.AsQueryable);

            _repositoryManagerMock.Setup(r => r.Save()).Returns(Task.CompletedTask);

            await _taskService.SaveChangesInTaskListForPatch(taskResponseModel, taskEntity, userId);

            _repositoryManagerMock.Verify(r => r.Save(), Times.Once);
        }

        [Fact]
        public async Task SaveChangesInTaskListForPatch_ShouldThrowBadRequestException_WhenOrderInvalid()
        {
            var taskResponseModel = new TaskResponseModel { Order = 0 };
            var taskEntity = new Tasks { TaskListId = Guid.NewGuid() };
            var userId = "user123";

            _repositoryManagerMock.Setup(r => r.Task.GetTasksWithTaskListId(It.IsAny<Guid>(), true))
                .Returns(new List<Tasks> { taskEntity }.AsQueryable());

            await Assert.ThrowsAsync<BadRequestException>(() => _taskService.SaveChangesInTaskListForPatch(taskResponseModel, taskEntity, userId));
        }

        [Fact]
        public async Task IsTaskListAvailable_ShouldReturnTrue_WhenTaskListIsAvailable()
        {
            var taskListId = Guid.NewGuid();
            var taskList = new TaskList { Id = taskListId, MaxTasks = 5 };
            var tasks = new List<Tasks> { new Tasks(), new Tasks() };

            _repositoryManagerMock.Setup(r => r.TaskList.GetByCondition(It.IsAny<Expression<Func<TaskList, bool>>>(), false))
                .Returns((new List<TaskList> { taskList }).AsQueryable());

            _repositoryManagerMock.Setup(r => r.Task.GetTasksWithTaskListId(It.IsAny<Guid>(), false))
                .Returns(tasks.AsQueryable());

            var result = await _taskService.IsTaskListAvailable(taskListId);

            Assert.True(result);
        }

        [Fact]
        public async Task IsTaskListAvailable_ShouldReturnFalse_WhenTaskListIsNotAvailable()
        {
            var taskListId = Guid.NewGuid();
            var taskList = new TaskList { Id = taskListId, MaxTasks = 2 };
            var tasks = new List<Tasks> { new Tasks(), new Tasks(), new Tasks() };

            _repositoryManagerMock.Setup(r => r.TaskList.GetByCondition(It.IsAny<Expression<Func<TaskList, bool>>>(), false))
                .Returns((new List<TaskList> { taskList }).AsQueryable());

            _repositoryManagerMock.Setup(r => r.Task.GetTasksWithTaskListId(It.IsAny<Guid>(), false))
                .Returns(tasks.AsQueryable());

            var result = await _taskService.IsTaskListAvailable(taskListId);

            Assert.False(result);
        }

        [Fact]
        public async Task IsMemberInProject_ShouldReturnTrue_WhenMemberIsInProject()
        {
            var taskListId = Guid.NewGuid();
            var projectId = Guid.NewGuid();
            var taskList = new TaskList { Id = taskListId, ProjectId = projectId };
            var member = new Member { UserId = "user123", ProjectId = projectId };

            _repositoryManagerMock.Setup(r => r.TaskList.GetByCondition(It.IsAny<Expression<Func<TaskList, bool>>>(), false))
                .Returns((new List<TaskList> { taskList }).AsQueryable());

            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), false))
                .Returns((new List<Member> { member }).AsQueryable());

            var result = await _taskService.IsMemberInProject(taskListId, "user123");

            Assert.True(result);
        }

        [Fact]
        public async Task IsMemberInProject_ShouldReturnFalse_WhenMemberIsNotInProject()
        {
            var taskListId = Guid.NewGuid();
            var projectId = Guid.NewGuid();
            var taskList = new TaskList { Id = taskListId, ProjectId = projectId };

            _repositoryManagerMock.Setup(r => r.TaskList.GetByCondition(It.IsAny<Expression<Func<TaskList, bool>>>(), false))
                .Returns((new List<TaskList> { taskList }).AsQueryable());

            _repositoryManagerMock.Setup(r => r.Member.GetByCondition(It.IsAny<Expression<Func<Member, bool>>>(), false))
                .Returns(Enumerable.Empty<Member>().AsQueryable());

            var result = await _taskService.IsMemberInProject(taskListId, "user123");

            Assert.False(result);
        }

        [Fact]
        public async Task IsMemberInProject_ShouldThrowBadRequestException_WhenTaskListNotFound()
        {
            var taskListId = Guid.NewGuid();

            _repositoryManagerMock.Setup(r => r.TaskList.GetByCondition(It.IsAny<Expression<Func<TaskList, bool>>>(), false))
                .Returns(Enumerable.Empty<TaskList>().AsQueryable());

            await Assert.ThrowsAsync<BadRequestException>(() => _taskService.IsMemberInProject(taskListId, "user123"));
        }

        [Fact]
        public async Task SaveChangesForPatch_ShouldThrowBadRequestException_WhenOrderIsInvalid()
        {
            var taskResponseModel = new TaskResponseModel { Order = 0 };
            var taskEntity = new Tasks { TaskListId = Guid.NewGuid() };
            var userId = "user123";

            _repositoryManagerMock.Setup(r => r.Task.GetTasksWithTaskListId(It.IsAny<Guid>(), true))
                .Returns(new List<Tasks> { taskEntity }.AsQueryable());

            await Assert.ThrowsAsync<BadRequestException>(() => _taskService.SaveChangesForPatch(taskResponseModel, taskEntity, userId));
        }

        [Fact]
        public async Task SaveChangesForPatch_ShouldUpdateTasks_WhenValidOrder()
        {
            var taskResponseModel = new TaskResponseModel { Order = 2 };
            var taskEntity = new Tasks { TaskListId = Guid.NewGuid(), Order = 1 };
            var userId = "user123";
            var taskListId = taskEntity.TaskListId;
            var tasks = new List<Tasks> { taskEntity, new Tasks { Order = 2 } };

            //_mapperMock.Setup(m => m.Map<Tasks>(taskResponseModel, taskEntity)).Returns(taskEntity);

            _repositoryManagerMock.Setup(r => r.Task.GetTasksWithTaskListId(It.IsAny<Guid>(), true))
                .Returns(tasks.AsQueryable);

            _repositoryManagerMock.Setup(r => r.Save()).Returns(Task.CompletedTask);

            await _taskService.SaveChangesForPatch(taskResponseModel, taskEntity, userId);

            _repositoryManagerMock.Verify(r => r.Save(), Times.Once);
            Assert.Equal(1, tasks[0].Order);
            Assert.Equal(2, tasks[1].Order);
        }
    }
}
