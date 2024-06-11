using Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
    }
}
