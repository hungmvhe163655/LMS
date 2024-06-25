using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "Email Is Required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string? PassWord { get; set; }
        public string? AuCode { get;set; }
    }
}
