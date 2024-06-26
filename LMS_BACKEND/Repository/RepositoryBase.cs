﻿using Contracts.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DataContext _context;
        protected DbSet<T> entities;//Ignore this
        public RepositoryBase(DataContext context)
        {
            _context = context;
            entities = this._context.Set<T>();//Ignore this
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
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// Ignore these methods
        public T Find(int id)
        {
            try
            {
                return entities.Find(id);
            }
            catch (Exception)
            {

                return null;

            }

        }
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = entities;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.ToList();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression, bool Trackable) => !Trackable ?
            await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync()
            : await _context.Set<T>().Where(expression).ToListAsync();

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<PageModel<T>> GetPagedAsync(int page, int pageSize, bool Trackable)
        {
            var query = !Trackable ? _context.Set<T>().AsNoTracking() : _context.Set<T>();

            var totalRecords = await query.CountAsync();
            var data = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PageModel<T>
            {
                Page = page,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                Data = data
            };

        }
    }
}
