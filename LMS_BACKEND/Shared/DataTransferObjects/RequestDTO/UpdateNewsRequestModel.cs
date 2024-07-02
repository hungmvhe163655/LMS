using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class UpdateNewsRequestModel
    {
        public string? Content { get; set; }
        public string Title { get; set; } = null!;

    }
}
