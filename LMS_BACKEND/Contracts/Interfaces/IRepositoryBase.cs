using Entities;
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
        Task<PageModel<T>> GetPagedAsync(int page, int pageSize, bool Trackable);
        public T Find(int id);
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
    }

}
