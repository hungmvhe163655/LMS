using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        Task<Account> FindByNameAsync(string userName, bool Trackable);
        Task<IQueryable<Account>> FindByVerifierAsync(string userName, bool Trackable);
    }
}
