using Contracts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ScheduleRepository : RepositoryBase<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(DataContext context) : base(context)
        {
        }
        public async Task<bool> CheckForOverlap(DateTime newStart, DateTime newEnd, Guid deviceId)
        {
            var overlappingSchedule = await FindAll(false)
                .Where(s => s.DeviceId.Equals(deviceId) &&
                            s.EndDate > newStart &&
                            s.StartDate < newEnd)
                .FirstOrDefaultAsync();
            return overlappingSchedule != null;
        }
        public async Task<IEnumerable<Schedule>> GetScheduleByDevice(Guid deviceId, DateTime startTime, DateTime endTime, bool track)
            => await
            FindAll(track)
            .Where
                (x => x.DeviceId
                .Equals(deviceId) && ((x.StartDate >= startTime && x.StartDate < endTime) || (x.EndDate <= endTime && x.EndDate > startTime))
                ).Include(x => x.Device).Include(x => x.Account)
            .ToListAsync();
        public async Task<IEnumerable<Schedule>> GetAllByDevice(Guid id, bool track) => await FindAll(track).ToListAsync();
        public async Task CreateScheduleForDevice(Schedule schedule) => await CreateAsync(schedule);
        public void DeleteSchedule(Schedule schedule) => Delete(schedule);
        public void UpdateScheduleForDevice(Schedule schedule) => Update(schedule);
        public async Task<Schedule?> GetSchedule(Guid ScheduleId, bool track) => await GetByCondition(c => c.Id.Equals(ScheduleId), track).SingleOrDefaultAsync();
    }
}
