using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record RegisterAccountDTO (string UserName, string Password, string StudentID);
    public record AccountDTO(string UserName);
}
