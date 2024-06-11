﻿using System;
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
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool Trackable);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
