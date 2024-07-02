using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class ChangePasswordRequestModel
    {
        [Required(ErrorMessage = "UserId is required")]
        public string UserID { get; set; } = null!;
        [Required(ErrorMessage = "Old Password is required")]
        public string OldPassword { get; set; } = null!;
        [Required(ErrorMessage = "New Password is required")]
        public string NewPassword { get; set; } = null!;
    }
}
