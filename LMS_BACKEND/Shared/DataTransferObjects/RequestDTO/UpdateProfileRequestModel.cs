﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class UpdateProfileRequestModel
    {
        [Required(ErrorMessage = "User ID is required!")]
        public string UserID { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string RollNumber { get; set; } = null!;
        public string Major { get; set; } = null!;
        public string Specialized { get; set; } = null!;
    }
}
