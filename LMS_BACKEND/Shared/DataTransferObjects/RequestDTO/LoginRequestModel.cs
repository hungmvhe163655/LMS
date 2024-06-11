using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class LoginRequestModel
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? PassWord { get; set; }
    }
}
