﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestParameters
{
    public class FilesRequestParameters
    {
        public int? Top { get; set; }
        public int? Take { get; set; }
        public string? Sorting { get; set; }
    }
}
