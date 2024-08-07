using Shared.GlobalVariables;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class ScheduleRequestModel
    {
        public DateTime DateInput { get; set; } = DateTime.Now;

        public string? TimeFrame { get; set; } = TIME_FRAME.WEEK;
    }
}
