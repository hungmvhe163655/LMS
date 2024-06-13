using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{

    //test area
    public record SimpleLoginDTO(string userName, string password);
    public record SimpleLoginResponseDTO(string userName, string status);
    //end of test area
    public record RegisterAccountDTO (string userName, string password, string studentID);
    
    public record AccountDTO(Account user);
}
