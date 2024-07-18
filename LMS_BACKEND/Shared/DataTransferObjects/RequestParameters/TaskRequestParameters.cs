using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestParameters
{
    public class TaskRequestParameters : RequestParameters
    {
        public TaskRequestParameters() => OrderBy = "CreatedDate";
        public DateTime startDateFilter { get; set; }
        public DateTime endDateFilter { get; set; } = DateTime.MaxValue;
        public bool ValidCreatedDateRange => DateTime.Compare(startDateFilter, endDateFilter) < 0;
        public Guid ProjectIdFilter { get; set; }
        public string? TaskStatusFilter { get; set; }
        public string? SearchTerm { get; set; }
    }
}
