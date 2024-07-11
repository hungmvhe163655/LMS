using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

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
