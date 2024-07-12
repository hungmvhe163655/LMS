using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMemberService 
    {
        Task<IEnumerable<MemberResponseModel>> GetMembers(Guid projectId);
        Task DeleteMember(Guid id, Guid projectId);
    }
}
