using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class ScheduleRequestModel
    {
        [Required(ErrorMessage = "DeviceID can't be null")]
        public Guid DeviceId { get; set; }
        public DateTime DateInput { get; set; } = DateTime.Now;
    }
}
