using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Moq;
using Service;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using Shared.GlobalVariables;
using Xunit;

namespace LMS_UnitTest.ProjectTest
{

    public class GetProjectsTest
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ProjectService _projectService;

        public GetProjectsTest()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _projectService = new ProjectService(
                _repositoryManagerMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task GetProjects_ShouldReturnProjects_WhenProjectsExist()
        {
            // Arrange
            var userId = "user123";
            var projectParams = new ProjectRequestParameters();
            var projectsFromDb = new PagedList<Project>(new List<Project>
        {
            new Project
            {
                Id = Guid.NewGuid(),
                TaskLists = new List<TaskList>
                {
                    new TaskList
                    {
                        Tasks = new List<Tasks>
                        {
                            new Tasks { TaskStatus = TASK_STATUS.OPEN_TODO },
                            new Tasks { TaskStatus = TASK_STATUS.DOING }
                        }
                    }
                }
            }
        }, 1, 1, 1);

            var projectResponseModels = new List<ProjectResponseModel>
        {
            new ProjectResponseModel
            {
                Id = Guid.NewGuid(),
                TaskUndone = 2,
                ListTaskUndone = new List<TasksViewResponseModel>()
            }
        };

            _repositoryManagerMock.Setup(r => r.Project.GetProjectAsync(userId, projectParams, false))
                .ReturnsAsync(projectsFromDb);

            _mapperMock.Setup(m => m.Map<ProjectResponseModel>(It.IsAny<Project>()))
                .Returns(projectResponseModels.First());

            _mapperMock.Setup(m => m.Map<IEnumerable<TasksViewResponseModel>>(It.IsAny<IEnumerable<Task>>()))
                .Returns(new List<TasksViewResponseModel>());

            // Act
            var result = await _projectService.GetProjects(userId, projectParams, false);

            // Assert
            Assert.NotNull(result.projects);
            Assert.Equal(1, result.projects.Count());
            Assert.Equal(2, result.projects.First().TaskUndone);
            _repositoryManagerMock.Verify(r => r.Project.GetProjectAsync(userId, projectParams, false), Times.Once);
        }

        [Fact]
        public async Task GetProjects_ShouldThrowBadRequestException_WhenNoProjectsFound()
        {
            // Arrange
            var userId = "user123";
            var projectParams = new ProjectRequestParameters();

            _repositoryManagerMock.Setup(r => r.Project.GetProjectAsync(userId, projectParams, false))
                .ReturnsAsync((PagedList<Project>)null);

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() => _projectService.GetProjects(userId, projectParams, false));
        }

        [Fact]
        public async Task GetProjects_ShouldReturnProjects_WhenProjectsHaveNoTasks()
        {
            // Arrange
            var userId = "user123";
            var projectParams = new ProjectRequestParameters();
            var projectsFromDb = new PagedList<Project>(new List<Project>
        {
            new Project
            {
                Id = Guid.NewGuid(),
                TaskLists = new List<TaskList>()
            }
        }, 1, 1, 1);

            var projectResponseModels = new List<ProjectResponseModel>
        {
            new ProjectResponseModel
            {
                Id = Guid.NewGuid(),
                TaskUndone = 0,
                ListTaskUndone = new List<TasksViewResponseModel>()
            }
        };

            _repositoryManagerMock.Setup(r => r.Project.GetProjectAsync(userId, projectParams, false))
                .ReturnsAsync(projectsFromDb);

            _mapperMock.Setup(m => m.Map<ProjectResponseModel>(It.IsAny<Project>()))
                .Returns(projectResponseModels.First());

            _mapperMock.Setup(m => m.Map<IEnumerable<TasksViewResponseModel>>(It.IsAny<IEnumerable<Task>>()))
                .Returns(new List<TasksViewResponseModel>());

            // Act
            var result = await _projectService.GetProjects(userId, projectParams, false);

            // Assert
            Assert.NotNull(result.projects);
            Assert.Equal(1, result.projects.Count());
            Assert.Equal(0, result.projects.First().TaskUndone);
            _repositoryManagerMock.Verify(r => r.Project.GetProjectAsync(userId, projectParams, false), Times.Once);
        }

        [Fact]
        public async Task GetProjects_ShouldReturnProjects_WhenProjectsHaveAllTasksClosed()
        {
            // Arrange
            var userId = "user123";
            var projectParams = new ProjectRequestParameters();
            var projectsFromDb = new PagedList<Project>(new List<Project>
        {
            new Project
            {
                Id = Guid.NewGuid(),
                TaskLists = new List<TaskList>
                {
                    new TaskList
                    {
                        Tasks = new List<Tasks>
                        {
                            new Tasks { TaskStatus = TASK_STATUS.CLOSE },
                            new Tasks { TaskStatus = TASK_STATUS.CLOSE }
                        }
                    }
                }
            }
        }, 1, 1, 1);

            var projectResponseModels = new List<ProjectResponseModel>
        {
            new ProjectResponseModel
            {
                Id = Guid.NewGuid(),
                TaskUndone = 0,
                ListTaskUndone = new List<TasksViewResponseModel>()
            }
        };

            _repositoryManagerMock.Setup(r => r.Project.GetProjectAsync(userId, projectParams, false))
                .ReturnsAsync(projectsFromDb);

            _mapperMock.Setup(m => m.Map<ProjectResponseModel>(It.IsAny<Project>()))
                .Returns(projectResponseModels.First());

            _mapperMock.Setup(m => m.Map<IEnumerable<TasksViewResponseModel>>(It.IsAny<IEnumerable<Task>>()))
                .Returns(new List<TasksViewResponseModel>());

            // Act
            var result = await _projectService.GetProjects(userId, projectParams, false);

            // Assert
            Assert.NotNull(result.projects);
            Assert.Equal(1, result.projects.Count());
            Assert.Equal(0, result.projects.First().TaskUndone);
            _repositoryManagerMock.Verify(r => r.Project.GetProjectAsync(userId, projectParams, false), Times.Once);
        }
    }
}
