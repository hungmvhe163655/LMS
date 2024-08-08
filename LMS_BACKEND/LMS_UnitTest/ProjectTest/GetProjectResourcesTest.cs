using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using LMS_UnitTest.Helper;
using Moq;
using Service;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using Shared.GlobalVariables;
using Xunit;

namespace LMS_UnitTest.ProjectTest
{

    public class GetProjectResources
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ProjectService _projectService;

        public GetProjectResources()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _projectService = new ProjectService(
                _repositoryManagerMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task GetProjectResources_ShouldReturnFilesAndFolders_WhenRootExists()
        {
            // Arrange
            var projectId = Guid.NewGuid();
            var rootFolder = new Folder { Id = Guid.NewGuid() };
            var files = new List<Files> { new Files { Id = Guid.NewGuid() } };

            _repositoryManagerMock.Setup(r => r.Folder.GetRootByProjectId(projectId))
                .Returns(new List<Folder> { rootFolder }.AsQueryable());

            _repositoryManagerMock.Setup(r => r.File.GetFiles(false, rootFolder.Id))
                .ReturnsAsync(files);

            // Act
            var result = await _projectService.GetProjectResources(projectId);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.Files);
            Assert.Empty(result.Folders);
            _repositoryManagerMock.Verify(r => r.Folder.GetRootByProjectId(projectId), Times.Once);
            _repositoryManagerMock.Verify(r => r.File.GetFiles(false, rootFolder.Id), Times.Once);
        }

        [Fact]
        public async Task GetProjectResources_ShouldThrowException_WhenRootDoesNotExist()
        {
            // Arrange
            var projectId = Guid.NewGuid();

            _repositoryManagerMock.Setup(r => r.Folder.GetRootByProjectId(projectId))
                .Returns(new List<Folder>().AsQueryable());

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _projectService.GetProjectResources(projectId));
            _repositoryManagerMock.Verify(r => r.Folder.GetRootByProjectId(projectId), Times.Once);
            _repositoryManagerMock.Verify(r => r.File.GetFiles(It.IsAny<bool>(), It.IsAny<Guid>()), Times.Never);
        }

        [Fact]
        public async Task GetProjectResources_ShouldReturnEmptyFilesAndFolders_WhenNoFilesExist()
        {
            // Arrange
            var projectId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            var rootFolder = new Folder { Id = Guid.Parse("00000000-0000-0000-0000-000000000000") };

            var mockQueryable = MockQueryableExtensions.CreateMockQueryable((new List<Folder> { rootFolder }).AsQueryable());

            _repositoryManagerMock.Setup(r => r.Folder.GetRootByProjectId(projectId))
                .Returns(mockQueryable.Object);

            _repositoryManagerMock.Setup(r => r.File.GetFiles(false, rootFolder.Id))
                .ReturnsAsync(new List<Files>());

            // Act
            var result = await _projectService.GetProjectResources(projectId);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.Files);
            Assert.Empty(result.Folders);
            _repositoryManagerMock.Verify(r => r.Folder.GetRootByProjectId(projectId), Times.Once);
            _repositoryManagerMock.Verify(r => r.File.GetFiles(false, rootFolder.Id), Times.Once);
        }
    }
}
