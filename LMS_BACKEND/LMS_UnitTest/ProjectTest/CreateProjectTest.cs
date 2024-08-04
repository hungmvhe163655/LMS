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
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ProjectService _projectServiceMock;

        public CreateProjectTest()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _projectServiceMock = new ProjectService(
                _repositoryManagerMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task CreateNewProject_ShouldCreateProject_WhenModelIsValid()
        {
            // Arrange
            var userId = "user123";
            var model = new CreateProjectRequestModel
            {
                Name = "Sample Project",
                Description = "Sample Description",
                MaxMember = 10,
                IsRecruiting = true,
                ProjectTypeId = 1
            };

            var project = new Project
            {
                Id = new Guid("160aee46-53e2-453f-ba16-59b82e0f4ff1"),
                Name = model.Name,
                Description = model.Description,
                CreatedDate = DateTime.Now,
                ProjectStatus = PROJECT_STATUS.INITIALIZING
            };

            var folderId = Guid.NewGuid();
            var folder = new Folder
            {
                Id = folderId,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                IsRoot = true,
                LastModifiedDate = DateTime.Now,
                ProjectId = project.Id,
                Name = project.Id + "Root",
                FolderClosureAncestor = new List<FolderClosure> { new FolderClosure { AncestorID = folderId, DescendantID = folderId, Depth = 0 } }
            };

            var member = new Member
            {
                UserId = userId,
                ProjectId = project.Id,
                IsLeader = true,
                JoinDate = DateTime.Now,
            };

            _mapperMock.Setup(m => m.Map<Project>(model)).Returns(project);
            _mapperMock.Setup(m => m.Map<ProjectViewResponseModel>(project)).Returns(new ProjectViewResponseModel
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description
            });

            _repositoryManagerMock.Setup(r => r.Project.Create(It.IsAny<Project>()));
            _repositoryManagerMock.Setup(r => r.Member.Create(It.IsAny<Member>()));
            _repositoryManagerMock.Setup(r => r.Folder.AddFolder(It.IsAny<Folder>())).Returns(Task.FromResult(true));
            _repositoryManagerMock.Setup(r => r.Save()).Returns(Task.CompletedTask);

            // Act
            var result = await _projectServiceMock.CreateNewProject(userId, model);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(project.Id, result.Id);
            Assert.Equal(model.Name, result.Name);
            Assert.Equal(model.Description, result.Description);

            _repositoryManagerMock.Verify(r => r.Project.Create(It.IsAny<Project>()), Times.Once);
            _repositoryManagerMock.Verify(r => r.Member.Create(It.IsAny<Member>()), Times.Once);
            _repositoryManagerMock.Verify(r => r.Folder.AddFolder(It.IsAny<Folder>()), Times.Once);
            _repositoryManagerMock.Verify(r => r.Save(), Times.Once);
        }

        [Fact]
        public async Task CreateNewProject_ShouldThrowException_WhenModelIsNull()
        {
            // Arrange
            CreateProjectRequestModel model = null;

            // Act & Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => _projectServiceMock.CreateNewProject("user123", model));
        }

        [Fact]
        public async Task CreateNewProject_ShouldThrowException_WhenUserIdIsEmpty()
        {
            // Arrange
            var model = new CreateProjectRequestModel
            {
                Name = "Sample Project",
                Description = "Sample Description",
                MaxMember = 10,
                IsRecruiting = true,
                ProjectTypeId = 1
            };

            // Act & Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => _projectServiceMock.CreateNewProject(string.Empty, model));
        }

    }
}
