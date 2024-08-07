﻿using Entities.Models;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface IScheduleService
    {
        Task<IEnumerable<ScheduleResponseModel>> GetScheduleForDevice(ScheduleRequestModel model, Guid id);
        Task DeleteSchedule(Guid id);
        Task UpdateSchedule(Guid id, ScheduleUpdateRequestModel model);
        Task<ScheduleResponseModel> CreateScheduleForDevice(ScheduleCreateRequestModel model);
        Task<ScheduleRequestModel> GetSchedule(Guid id);
        Task<IEnumerable<Schedule>> GetDueSchedulesAsync();
    }
}
