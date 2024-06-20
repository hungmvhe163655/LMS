using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class RegisterRequestModel
    {
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? VerifiedByUserID { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        public ICollection<string>? Roles { get; init; }
    }
}
