using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class ForgotPasswordRequestModel
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
