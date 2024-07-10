using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class ScheduleRequestModel
    {
        [Required(ErrorMessage = "DeviceID can't be null")]
        public Guid DeviceId { get; set; }
        public DateTime DateInput { get; set; } = DateTime.Now;
    }
}
