using Shared.DataTransferObjects.RequestParameters;
using System.Linq.Expressions;

namespace Contracts.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll(bool Trackable);
        Task<IEnumerable<T>> FindAllAsync(bool Trackable);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool Trackable);
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression, bool Trackable);
        void Create(T entity);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> GetPagedAsync(RequestParameters lamao, bool Trackable);
        void DeleteRange(IEnumerable<T> entities);
        Task<bool> UpdateWithConcurrencyAsync(T entity);
        Task<bool> DeleteWithConcurrencyAsync(T entity);
    }

}
