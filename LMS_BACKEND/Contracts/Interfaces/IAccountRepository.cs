using Entities.Models;
using Shared.DataTransferObjects.RequestParameters;

namespace Contracts.Interfaces
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        Task<Account?> FindByNameAsync(string userName, bool Trackable);
        Task<PagedList<Account>> FindWithVerifierId(NeedVerifyParameters param);
    }
}
