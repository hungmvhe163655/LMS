using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class UpdateDeviceRequestModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Filekey { get; set; }
    }
}
