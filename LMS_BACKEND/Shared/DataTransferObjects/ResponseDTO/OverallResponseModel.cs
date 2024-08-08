using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class OverallResponseModel
    {
        public int ActiveProject { get; set; }
        public int Member { get; set; }
        public int Device { get; set; }
    }
}
