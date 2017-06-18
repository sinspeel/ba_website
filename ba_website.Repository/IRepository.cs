﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ba_website.Repository
{
    public interface IRepository<T>: IDisposable
    {
        void InsertOrUpdate(T entity, bool IsSaveChanges = false);
        void Delete(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        Task<List<T>> GetAllListAsync();
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        void Dispose();
    }
}
