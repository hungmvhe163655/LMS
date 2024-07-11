using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class UpdateTaskListRequestModel
    {
        public string Name { get; set; } = null!;
        public int MaxTasks { get; set; }
    }
}
