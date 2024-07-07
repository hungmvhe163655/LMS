using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class ScheduleCreateRequestModel
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public string AccountId { get; set; } = null!;
        public DateTime ScheduledDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Purpose { get; set; }
    }
}
