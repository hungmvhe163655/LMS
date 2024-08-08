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

namespace LMS_UnitTest.DeviceTest
{
    public class CreateNewDeviceTest
    {
        private readonly Mock<IRepositoryManager> _repositoryManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly DeviceService _deviceService;

        public CreateNewDeviceTest()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _deviceService = new DeviceService(_repositoryManagerMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task CreateNewDevice_ShouldReturnDeviceReturnModel_WhenValidModel()
        {
            // Arrange
            var userId = "user123";
            var createDeviceRequestModel = new CreateDeviceRequestModel
            {
                Name = "Device1",
                Description = "Description1",
                Filekey = "filekey1"
            };

            var device = new Device
            {
                Id = Guid.NewGuid(),
                Name = createDeviceRequestModel.Name,
                Description = createDeviceRequestModel.Description,
                Filekey = createDeviceRequestModel.Filekey,
                OwnedBy = userId,
                LastUsed = DateTime.UtcNow,
                IsDeleted = false,
                DeviceStatus = DEVICE_STATUS.AVAILABLE
            };

            _mapperMock.Setup(m => m.Map<Device>(createDeviceRequestModel)).Returns(device);
            _repositoryManagerMock.Setup(r => r.Device.CreateAsync(device)).Returns(Task.CompletedTask);
            _repositoryManagerMock.Setup(r => r.Save()).Returns(Task.CompletedTask);
            _mapperMock.Setup(m => m.Map<DeviceReturnModel>(device)).Returns(new DeviceReturnModel
            {
                Id = device.Id,
                DeviceStatus = device.DeviceStatus.ToString(),
                OwnedBy = device.OwnedBy,
                Name = device.Name,
                Description = device.Description,
                LastUsed = device.LastUsed,
                IsDeleted = device.IsDeleted,
                Filekey = device.Filekey
            });

            // Act
            var result = await _deviceService.CreateNewDevice(userId, createDeviceRequestModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(device.DeviceStatus.ToString(), result.DeviceStatus);
            Assert.Equal(device.OwnedBy, result.OwnedBy);
            Assert.Equal(device.Name, result.Name);
            Assert.Equal(device.Description, result.Description);
            Assert.Equal(device.IsDeleted, result.IsDeleted);
            Assert.Equal(device.Filekey, result.Filekey);
        }

        [Fact]
        public async Task CreateNewDevice_ShouldThrowException_WhenRepositoryThrowsException()
        {
            // Arrange
            var userId = "user123";
            var createDeviceRequestModel = new CreateDeviceRequestModel
            {
                Name = "Device1",
                Description = "Description1",
                Filekey = "filekey1"
            };

            var device = new Device
            {
                Id = Guid.NewGuid(),
                Name = createDeviceRequestModel.Name,
                Description = createDeviceRequestModel.Description,
                Filekey = createDeviceRequestModel.Filekey,
                OwnedBy = userId,
                LastUsed = DateTime.UtcNow,
                IsDeleted = false,
                DeviceStatus = DEVICE_STATUS.AVAILABLE
            };

            _mapperMock.Setup(m => m.Map<Device>(createDeviceRequestModel)).Returns(device);
            _repositoryManagerMock.Setup(r => r.Device.CreateAsync(device)).ThrowsAsync(new Exception("Database error"));
            _repositoryManagerMock.Setup(r => r.Save()).Returns(Task.CompletedTask);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _deviceService.CreateNewDevice(userId, createDeviceRequestModel));
        }

        [Fact]
        public async Task CreateNewDevice_ShouldThrowException_WhenSaveFails()
        {
            // Arrange
            var userId = "user123";
            var createDeviceRequestModel = new CreateDeviceRequestModel
            {
                Name = "Device1",
                Description = "Description1",
                Filekey = "filekey1"
            };

            var device = new Device
            {
                Id = Guid.NewGuid(),
                Name = createDeviceRequestModel.Name,
                Description = createDeviceRequestModel.Description,
                Filekey = createDeviceRequestModel.Filekey,
                OwnedBy = userId,
                LastUsed = DateTime.UtcNow,
                IsDeleted = false,
                DeviceStatus = DEVICE_STATUS.AVAILABLE
            };

            _mapperMock.Setup(m => m.Map<Device>(createDeviceRequestModel)).Returns(device);
            _repositoryManagerMock.Setup(r => r.Device.CreateAsync(device)).Returns(Task.CompletedTask);
            _repositoryManagerMock.Setup(r => r.Save()).ThrowsAsync(new Exception("Save error"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _deviceService.CreateNewDevice(userId, createDeviceRequestModel));
        }
    }
}
