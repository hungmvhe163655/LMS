using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IDeviceService
    {
        Task<(IEnumerable<DeviceReturnModel> data, MetaData meta)> GetDevice(DeviceRequestParameters param);
    }
}
