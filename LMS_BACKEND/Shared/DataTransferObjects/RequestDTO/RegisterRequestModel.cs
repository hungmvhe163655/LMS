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
        public string FullName { get; set; } = null!;
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string VerifiedByUserID { get; set; } = null!;
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;
        public ICollection<string> Roles { get; init; } = null!;
    }
}
