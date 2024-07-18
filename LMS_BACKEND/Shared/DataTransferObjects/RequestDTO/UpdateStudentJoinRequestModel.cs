using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class UpdateStudentJoinRequestModel
    {
        public string Id { get; set; } = null!;
        public bool Accepted { get; set; } = false;
        public Guid ProjectID { get; set; }
    }
}
