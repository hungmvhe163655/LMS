using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class ResponseObjectModel
    {
        public string? Status { get; set; }
        public int? Code { get; set; }
        public Object? Value { get; set; }
    }
}
