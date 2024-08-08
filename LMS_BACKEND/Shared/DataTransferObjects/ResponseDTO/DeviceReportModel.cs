using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class DeviceReportModel
    {
        public int InUse { get; set; }
        public int Available { get; set; }
        public int Disable { get; set; }
    }
}
