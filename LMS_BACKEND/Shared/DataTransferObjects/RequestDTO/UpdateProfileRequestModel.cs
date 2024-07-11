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
        public string Id { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public bool Gender { get; set; } = true;
        public string? Major { get; set; }
        public string? Specialized { get; set; }
    }
}
