using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestParameters
{
    public class NeedVerifyParameters : RequestParameters
    {
        public string? SearchContent { get; set; } = null!;

        public string? UserId { get; set; } = null!;
    }
}
