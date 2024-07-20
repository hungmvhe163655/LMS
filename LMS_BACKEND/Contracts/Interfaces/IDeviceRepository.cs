using Entities.Models;
using Shared.DataTransferObjects.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IDeviceRepository : IRepositoryBase<Device>
    {
        Task<PagedList<Device>> GetWithParam(DeviceRequestParameters param);
    }
}
