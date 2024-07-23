using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestParameters
{
    public class ProjectRequestParameters : RequestParameters
    {
        public ProjectRequestParameters() => OrderBy = "CreatedDate";
        public DateTime MinCreatedDate { get; set; }
        public DateTime MaxCreatedDate { get; set; } = DateTime.MaxValue;

        public bool ValidCreatedDateRange => DateTime.Compare(MinCreatedDate, MaxCreatedDate) < 0;
        public string? SearchTerm { get; set; }
        public string? ProjectStatusFilter { get; set; }
        public int ProjectTypeId { get; set; }
    }
}
