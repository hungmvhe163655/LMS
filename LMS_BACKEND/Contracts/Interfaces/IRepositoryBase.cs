using System.Linq.Expressions;

namespace Contracts.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool Trackable);
        Task<IEnumerable<T>> FindAllAsync(bool Trackable);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool Trackable);
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression, bool Trackable);
        void Create(T entity);
        Task CreateAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
    }
}
