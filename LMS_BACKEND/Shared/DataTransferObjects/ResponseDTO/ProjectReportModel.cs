using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class ProjectReportModel
    {
        public int Initializing { get; set; }
        public int Ongoing { get; set; }
        public int Completed { get; set; }
        public int Cancel { get; set; }
    }
}
