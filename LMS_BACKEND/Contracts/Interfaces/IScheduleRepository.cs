using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IScheduleRepository
    {
        Task<bool> CheckForOverlap(DateTime newStart, DateTime newEnd, Guid deviceId);
        Task<IEnumerable<Schedule>> GetScheduleByDevice(Guid deviceId, DateTime startTime, DateTime endTime, bool track);
        Task<IEnumerable<Schedule>> GetAllByDevice(Guid deviceId, bool track);
        Task CreateScheduleForDevice(Schedule schedule);
        void UpdateScheduleForDevice(Schedule schedule);
        void DeleteSchedule(Schedule schedule);
        Task<Schedule?> GetSchedule(Guid ScheduleId, bool track);
    }
}
