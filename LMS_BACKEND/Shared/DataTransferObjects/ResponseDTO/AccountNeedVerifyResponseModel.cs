using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class AccountNeedVerifyResponseModel
    {
        public string Id { get; set; } = null!;
        public string FullName { get; set; } = null!;
    }
}
