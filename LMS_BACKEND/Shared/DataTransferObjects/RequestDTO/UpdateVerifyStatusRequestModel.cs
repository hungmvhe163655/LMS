using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class UpdateVerifyStatusRequestModel
    {
        [Required(ErrorMessage = "UserId is required")]
        public string? UserID { get; set; }
        public string? verifierID { get; set; }
    }
}
