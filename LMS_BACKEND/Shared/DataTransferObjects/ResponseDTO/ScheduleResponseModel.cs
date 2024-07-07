using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class ScheduleResponseModel
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Purpose { get; set; }
        public DeviceReturnModel Device { get; set; } = null!;
        public AccountReturnModel Account { get; set; } = null!;
    }
}
