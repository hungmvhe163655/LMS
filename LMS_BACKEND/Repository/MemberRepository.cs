using Contracts.Interfaces;
using Entities.Models;

namespace Repository
{
    public class MemberRepository : RepositoryBase<Member>, IMemberRepository
    {
        public MemberRepository(DataContext context) : base(context)
        {
        }
    }
}
