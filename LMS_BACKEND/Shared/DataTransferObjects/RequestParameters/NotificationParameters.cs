using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestParameters
{
    public class NotificationParameters : RequestParameters
    {
        public string? NotificationType { get; set; }
        [Required]
        public string UserId { get; set; } = null!;

        public bool Read { get; set; } = false;

        public NotificationParameters() => OrderBy = "CreatedDate";
    }
}
