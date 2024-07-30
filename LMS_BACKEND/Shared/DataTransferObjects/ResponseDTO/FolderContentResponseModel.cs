using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class FolderContentResponseModel
    {
        public IEnumerable<Object> ListObject { get; set; } = null!;
        public int Remaining { get; set; } = 0;
    }
}
