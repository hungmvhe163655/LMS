using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IScheduleService
    {
        Task<IEnumerable<ScheduleResponseModel>> GetScheduleForDevice(ScheduleRequestModel model);
        Task DeleteSchedule(Guid id);
        Task UpdateSchedule(Guid id, ScheduleUpdateRequestModel model);
        Task CreateScheduleForDevice(ScheduleCreateRequestModel model);
    }
}
