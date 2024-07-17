﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestParameters
{
    public class ProjectRequestParameters : RequestParameters
    {
        public ProjectRequestParameters() => OrderBy = "CreatedDate";
        public DateTime minCreatedDate { get; set; }
        public DateTime maxCreatedDate { get; set; } = DateTime.MaxValue;

        public bool ValidCreatedDateRange => DateTime.Compare(minCreatedDate, maxCreatedDate) < 0;
        public string? SearchTerm { get; set; }
    }
}
