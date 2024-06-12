using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
