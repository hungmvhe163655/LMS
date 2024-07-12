using Entities.Models;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class MemberResponseModel
    {
        public string FullName { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public bool IsLeader { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
