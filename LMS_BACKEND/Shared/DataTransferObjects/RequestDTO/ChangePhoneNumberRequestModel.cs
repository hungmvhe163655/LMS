using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class ChangePhoneNumberRequestModel
    {
        [Required(ErrorMessage = "Phone Number is required")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Verify Code is required")]
        public string? VerifyCode { get; set; }
    }
}
