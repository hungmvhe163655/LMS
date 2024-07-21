using Contracts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DeviceRepository : RepositoryBase<Device>, IDeviceRepository
    {
        public DeviceRepository(DataContext context) : base(context)
        {
        }
        public async Task<PagedList<Device>> GetWithParam(DeviceRequestParameters param)
        {
            var hold = await FindAll(false).ToListAsync();

            return new PagedList<Device>(hold, hold.Count, param.PageNumber, param.PageSize);
        }
    }
}
