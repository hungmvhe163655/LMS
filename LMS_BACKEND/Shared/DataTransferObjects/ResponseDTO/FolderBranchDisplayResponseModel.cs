﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class FolderBranchDisplayResponseModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Depth { get; set; } = 0;
    }
}
