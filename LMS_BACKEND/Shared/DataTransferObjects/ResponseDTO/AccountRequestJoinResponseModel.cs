using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class AccountRequestJoinResponseModel
    {
        public string Id { get; set; } = null!;

        public DateTime CreatedDate { get; set; }
        public string FullName { get; set; } = null!;
    }
}
