using Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IEnumerable<T>> FindAllAsync(bool Trackable) => !Trackable ?
          await _context.Set<T>().AsNoTracking().ToListAsync()
          : await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression, bool Trackable) => !Trackable ?
            await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync()
            : await _context.Set<T>().Where(expression).ToListAsync();

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
