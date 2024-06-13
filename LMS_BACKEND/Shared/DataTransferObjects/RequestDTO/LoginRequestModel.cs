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
        public string? Email { get; set; }
        [Required(ErrorMessage = "Username Is Required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string? PassWord { get; set; }
    }
}
