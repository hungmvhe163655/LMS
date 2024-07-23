using AutoMapper;
using Contracts.Interfaces;
using Service.Contracts;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
