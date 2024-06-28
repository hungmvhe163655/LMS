using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestParameters
{
    public class FileRequestParameters : RequestParameters
    {
        public bool? OrderByName { get; set; } = true!;
        public bool? OrderBySize { get; set; } = true!;
        public string? SearchTerm { get; set; }
    }
}
