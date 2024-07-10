using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.RequestDTO
{
    public class ChangeVerifierRequestModel
    {
        public string Id { get; set; } = null!;
        public string VerifierId { get; set; } = null!;
    }
}
