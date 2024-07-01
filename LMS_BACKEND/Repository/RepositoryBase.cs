using Contracts.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects.RequestParameters;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DataContext _context;
        public RepositoryBase(DataContext context)
        {
            _context = context;
        }

        public IQueryable<T> FindAll(bool Trackable) => !Trackable ?
            _context.Set<T>().AsNoTracking()
            : _context.Set<T>();

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool Trackable) => !Trackable ?
            _context.Set<T>()
            .Where(expression)
            .AsNoTracking()
            : _context.Set<T>()
            .Where(expression);

        public void Update(T entity) => _context.Set<T>().Update(entity);

        public void Create(T entity) => _context.Set<T>().Add(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public async Task<IEnumerable<T>> FindAllAsync(bool Trackable) => !Trackable ?
          await _context.Set<T>().AsNoTracking().ToListAsync()
          : await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression, bool Trackable) => !Trackable ?
            await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync()
            : await _context.Set<T>().Where(expression).ToListAsync();

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetPagedAsync(RequestParameters lamao, bool Trackable)
        {
            var query = !Trackable ? _context.Set<T>().AsNoTracking() : _context.Set<T>();
            return PagedList<T>.ToPagedList(await query.ToListAsync(), lamao.PageNumber, lamao.PageSize);
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}
