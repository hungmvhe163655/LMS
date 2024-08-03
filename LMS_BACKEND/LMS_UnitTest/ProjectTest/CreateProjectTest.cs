using AutoMapper;
using Contracts.Interfaces;
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
        private ProjectService _projectService;

        public CreateProjectTest()
        {
            _mapperMock = new Mock<IMapper>();
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _projectService = new ProjectService(
                _repositoryManagerMock.Object,
                _mapperMock.Object);
        }

        //[Fact]
        //public async Task CreateProject_WithValidInput_ReturnProjectViewResponseModel()
        //{
        //    var createResquest = new CreateProjectRequestModel
        //    {
        //        Name = "Test",
        //        Description = "Testing",
        //        IsRecruiting = true,
        //        MaxMember = 4,
        //        ProjectTypeId = 1
        //    };

        //    var userId = "userId";

        //    var project = new Project
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = createResquest.Name,
        //        Description = createResquest.Description,
        //        IsRecruiting = createResquest.IsRecruiting,
        //        MaxMember = createResquest.MaxMember,
        //        ProjectTypeId = createResquest.ProjectTypeId,
        //        CreatedDate = DateTime.Now,
        //        ProjectStatus = PROJECT_STATUS.INITIALIZING
        //    };

        //    _mapperMock.Setup(m => m.Map<Project>(createResquest)).Returns(project);



        //}
    }
}
