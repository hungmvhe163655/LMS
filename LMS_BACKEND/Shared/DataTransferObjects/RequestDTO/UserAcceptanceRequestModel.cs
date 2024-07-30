using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class UserAcceptanceRequestModel
    {
        public string UserId { get; set; } = null!;
        public bool IsApproved { get; set; } = true;
    }
}
