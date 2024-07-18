using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class CreateReportRequestModel
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
        public int DeviceStatusId { get; set; }
        public string? Description { get; set; }
        public string? FileKey { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
