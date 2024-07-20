using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class AccountManagementResponseModel
    {
        public string Id { get; set; } = null!;
        public string? FullName { get; set; }
        public string Gender { get; set; } = "Male";
        public string? VerifiedBy { get; set; }
        public string? Status { get; set; }
        public IList<string>? Role { get; set; }
    }
}
