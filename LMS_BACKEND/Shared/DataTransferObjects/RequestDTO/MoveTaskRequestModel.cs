using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class MoveTaskRequestModel
    {
        public Guid Id { get; set; }
        public Guid TaskListId { get; set; }
    }
}
