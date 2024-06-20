using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class ForgotPasswordRequestModel
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? VerifyCode { get; set; }
        //1 Screen Step=1 second Step=2
        public int Step { get; set; }
        public string? Password { get; set; }
    }
}
