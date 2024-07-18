using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestParameters
{
    public class ReportRequestParameters : RequestParameters
    {
        public string? SearchContent { get; set; } = null!;
        public Guid? DeviceID { get; set; }
    }
}
