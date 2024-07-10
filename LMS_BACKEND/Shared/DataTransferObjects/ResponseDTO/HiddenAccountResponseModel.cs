using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class HiddenAccountResponseModel
    {
        public string AccountId { get; set; } = null!;
        public string VerifierId { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
