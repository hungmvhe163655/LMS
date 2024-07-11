﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class ChangeEmailRequestModel
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
