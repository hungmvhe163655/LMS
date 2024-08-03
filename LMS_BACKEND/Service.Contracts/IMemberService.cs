using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberResponseModel>> GetMembers(Guid projectId);
        Task DeleteMember(Guid id, Guid projectId);

        Task<Guid> GetProjectIdWithMemberId(string MemberId);
    }
}
