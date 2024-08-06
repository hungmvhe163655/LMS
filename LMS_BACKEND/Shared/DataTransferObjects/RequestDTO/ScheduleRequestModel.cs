using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class ScheduleRequestModel
    {
        public DateTime DateInput { get; set; } = DateTime.Now;
    }
}
