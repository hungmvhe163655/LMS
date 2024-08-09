using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class FilesDownloadRequestModel
    {
        public List<Guid> ListId { get; set; } = new List<Guid>();
    }
}
