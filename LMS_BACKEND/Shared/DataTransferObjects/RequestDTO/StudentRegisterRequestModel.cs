using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class StudentRegisterRequestModel
    {
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid SupervisorID { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        public ICollection<string>? Roles { get; init; }
    }
}
