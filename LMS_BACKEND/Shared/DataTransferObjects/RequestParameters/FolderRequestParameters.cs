using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestParameters
{
    public class FolderRequestParameters
    {
        public int? Cursor { get; set; }
        public int? Take { get; set; }
        public string? OrderBy { get; set; }
    }
}
