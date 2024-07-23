using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestParameters
{
    public class NotificationParameters : RequestParameters
    {
        public string? NotificationType { get; set; }  

        public NotificationParameters() => OrderBy = "CreatedDate";
    }
}
