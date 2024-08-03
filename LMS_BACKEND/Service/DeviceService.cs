using AutoMapper;
using Contracts.Interfaces;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.GlobalVariables;
using Microsoft.EntityFrameworkCore;
using Entities.Exceptions;

namespace Service
{
    public class DeviceService : IDeviceService
    {
        private readonly IRepositoryManager _repository;

        private readonly IMapper _mapper;

        public DeviceService(IRepositoryManager repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<(IEnumerable<DeviceReturnModel> data, MetaData meta)> GetDevice(DeviceRequestParameters param)
        {
            var hold = await _repository.Device.GetWithParam(param);

            return (_mapper.Map<IEnumerable<DeviceReturnModel>>(hold), hold.MetaData);
        }

        public async Task<DeviceReturnModel> CreateNewDevice(string userId, CreateDeviceRequestModel model)
        {
            var hold = _mapper.Map<Device>(model);

            hold.Id = Guid.NewGuid();
            hold.OwnedBy = userId;
            hold.LastUsed = DateTime.UtcNow;
            hold.IsDeleted = false;
            hold.DeviceStatus = DEVICE_STATUS.AVAILABLE;

            await _repository.Device.CreateAsync(hold);
            await _repository.Save();

            return _mapper.Map<DeviceReturnModel>(hold);
        }

        public async Task UpdateDevice(Guid id, UpdateDeviceRequestModel model)
        {
            var hold = await _repository.Device.GetByCondition(d => d.Id.Equals(id), true).FirstOrDefaultAsync() ?? throw new BadRequestException($"Can find any device with id {id}");
            
            hold.Name = model.Name;
            hold.Description = model.Description;
            hold.Filekey = model.Filekey;

            await _repository.Save();
        }

        public async Task<DeviceReturnModel> GetDeviceById(Guid id)
        {
            var hold = await _repository.Device.GetByCondition(d => d.Id.Equals(id), false).FirstOrDefaultAsync() ?? throw new BadRequestException($"Can find any device with id {id}");
            return _mapper.Map<DeviceReturnModel>(hold);
        } 

        public async Task DeleteDevice(Guid id)
        {
            var hold = await _repository.Device.GetByCondition(d => d.Id.Equals(id), true).FirstOrDefaultAsync() ?? throw new BadRequestException($"Can find any device with id {id}");
            
            hold.DeviceStatus = DEVICE_STATUS.DISABLE;
            hold.IsDeleted = true;

            await _repository.Save();
        }
    }
}
