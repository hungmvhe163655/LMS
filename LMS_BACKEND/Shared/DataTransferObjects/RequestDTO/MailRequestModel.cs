using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class MailRequestModel
    {
        public string Email { get; set; } = null!;
        public string AuCode { get; set; } = null!;
    }
}
