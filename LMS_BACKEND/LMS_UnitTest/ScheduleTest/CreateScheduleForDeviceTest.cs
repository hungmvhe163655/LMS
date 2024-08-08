using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Moq;
using Service;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LMS_UnitTest.ScheduleTest
{
    public class CreateScheduleForDeviceTest
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ScheduleService _scheduleServiceMock;

        public CreateScheduleForDeviceTest()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _scheduleServiceMock = new ScheduleService(
                _repositoryManagerMock.Object,
                _mapperMock.Object
                );
        }

        [Fact]
        public async Task CreateScheduleForDevice_ShouldReturnScheduleResponseModel_WhenNoOverlap()
        {
            // Arrange
            var requestModel = new ScheduleCreateRequestModel
            {
                DeviceId = Guid.NewGuid(),
                AccountId = "accountId",
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(2),
                Purpose = "Test Purpose"
            };
            var schedule = new Schedule
            {
                Id = Guid.NewGuid(),
                DeviceId = requestModel.DeviceId,
                StartDate = requestModel.StartDate,
                EndDate = requestModel.EndDate,
                Purpose = requestModel.Purpose
            };
            var responseModel = new ScheduleResponseModel
            {
                Id = schedule.Id,
                DeviceId = schedule.DeviceId,
                StartDate = schedule.StartDate,
                EndDate = schedule.EndDate,
                Purpose = schedule.Purpose,
                Device = new DeviceReturnModel(), // Mock or create as needed
                Account = new AccountReturnModel() // Mock or create as needed
            };

            _repositoryManagerMock.Setup(r => r.Schedule.CheckForOverlap(requestModel.StartDate, requestModel.EndDate, requestModel.DeviceId))
                           .ReturnsAsync(false);
            _mapperMock.Setup(m => m.Map<Schedule>(requestModel)).Returns(schedule);
            _mapperMock.Setup(m => m.Map<ScheduleResponseModel>(schedule)).Returns(responseModel);

            // Act
            var result = await _scheduleServiceMock.CreateScheduleForDevice(requestModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
            Assert.Equal(responseModel.DeviceId, result.DeviceId);
        }

        [Fact]
        public async Task CreateScheduleForDevice_ShouldThrowBadRequestException_WhenOverlapDetected()
        {
            // Arrange
            var requestModel = new ScheduleCreateRequestModel
            {
                DeviceId = Guid.NewGuid(),
                AccountId = "accountId",
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(2),
                Purpose = "Test Purpose"
            };

            _repositoryManagerMock.Setup(r => r.Schedule.CheckForOverlap(requestModel.StartDate, requestModel.EndDate, requestModel.DeviceId))
                           .ReturnsAsync(true);

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() => _scheduleServiceMock.CreateScheduleForDevice(requestModel));
        }

        [Fact]
        public async Task CreateScheduleForDevice_ShouldCreateScheduleWithNullPurpose()
        {
            // Arrange
            var requestModel = new ScheduleCreateRequestModel
            {
                DeviceId = Guid.NewGuid(),
                AccountId = "accountId",
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(2),
                Purpose = null
            };
            var schedule = new Schedule
            {
                Id = Guid.NewGuid(),
                DeviceId = requestModel.DeviceId,
                StartDate = requestModel.StartDate,
                EndDate = requestModel.EndDate,
                Purpose = requestModel.Purpose
            };
            var responseModel = new ScheduleResponseModel
            {
                Id = schedule.Id,
                DeviceId = schedule.DeviceId,
                StartDate = schedule.StartDate,
                EndDate = schedule.EndDate,
                Purpose = schedule.Purpose,
                Device = new DeviceReturnModel(), // Mock or create as needed
                Account = new AccountReturnModel() // Mock or create as needed
            };

            _repositoryManagerMock.Setup(r => r.Schedule.CheckForOverlap(requestModel.StartDate, requestModel.EndDate, requestModel.DeviceId))
                           .ReturnsAsync(false);
            _mapperMock.Setup(m => m.Map<Schedule>(requestModel)).Returns(schedule);
            _mapperMock.Setup(m => m.Map<ScheduleResponseModel>(schedule)).Returns(responseModel);

            // Act
            var result = await _scheduleServiceMock.CreateScheduleForDevice(requestModel);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Purpose);
        }
    }
}
