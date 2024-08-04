using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Moq;
using Service;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using Shared.GlobalVariables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LMS_UnitTest.ProjectTest
{
    public class CreateProjectTest
    {
        private readonly Mock<IRepositoryManager> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private ProjectService _projectService;

        public CreateProjectTest()
        {
            _repositoryMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _projectService = new ProjectService(_repositoryMock.Object, _mapperMock.Object);

            // Setup default behaviors for repository and mapper
            _repositoryMock.Setup(r => r.Project.Create(It.IsAny<Project>()));
            _repositoryMock.Setup(r => r.Member.Create(It.IsAny<Member>()));
            _repositoryMock.Setup(r => r.Folder.AddFolder(It.IsAny<Folder>()));
            _repositoryMock.Setup(r => r.Save()).Returns(Task.CompletedTask);
            _mapperMock.Setup(m => m.Map<Project>(It.IsAny<CreateProjectRequestModel>()))
                       .Returns((CreateProjectRequestModel source) => new Project
                       {
                           Name = source.Name,
                           Description = source.Description,
                           // Map other properties as needed
                       });
            _mapperMock.Setup(m => m.Map<ProjectViewResponseModel>(It.IsAny<Project>()))
                       .Returns((Project source) => new ProjectViewResponseModel
                       {
                           Name = source.Name,
                           Description = source.Description,
                           // Map other properties as needed
                       });

        }

        [Fact]
        public async Task CreateNewProject_WithValidData_CreatesProjectSuccessfully()
        {
            // Arrange
            var userId = "User123";
            var model = new CreateProjectRequestModel
            {
                Name = "New Project",
                Description = "Project Description",
                // Set other properties as needed
            };

            // Act
            var result = await _projectService.CreatNewProject(userId, model);

            // Assert
            _repositoryMock.Verify(r => r.Project.Create(It.IsAny<Project>()), Times.Once);
            _repositoryMock.Verify(r => r.Member.Create(It.IsAny<Member>()), Times.Once);
            _repositoryMock.Verify(r => r.Folder.AddFolder(It.IsAny<Folder>()), Times.Once);
            _repositoryMock.Verify(r => r.Save(), Times.Once);
            _mapperMock.Verify(m => m.Map<ProjectViewResponseModel>(It.IsAny<Project>()), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(model.Name, result.Name);
            Assert.Equal(model.Description, result.Description);
        }

        [Fact]
        public async Task CreateNewProject_WithInvalidUserId_ThrowsException()
        {
            // Arrange
            var userId = "";
            var model = new CreateProjectRequestModel
            {
                Name = "New Project",
                Description = "Project Description",
                // Set other properties as needed
            };

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() => _projectService.CreatNewProject(userId, model));
        }

    }
}
