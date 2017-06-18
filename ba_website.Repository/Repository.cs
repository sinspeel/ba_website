using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ba_website.model;

namespace ba_website.Repository
{
    public class Repository<T>:IRepository<T> where T:class
    {
        protected DbSet<T> DbSet;
        protected DbContext context;

        public Repository(DbContext context)
        {
            DbSet = context.Set<T>();
            this.context = context;
        }

        public void InsertOrUpdate(T entity,bool IsSaveChanges = false)
        {
            if(((IEntity)entity).Id==default(int))
            {
                DbSet.Add(entity);
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            if (IsSaveChanges)
                SaveChanges();
            
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<T>SearchFor(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
        public IQueryable<T> GetAll()
        {
            return DbSet;
        }
        public async Task<List<T>>GetAllListAsync()
        {
            return await DbSet.ToListAsync();
        }
        public T GetById(int id)
        {
            return DbSet.Find(id);
        }
        public async Task<T>GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Dispose()
        { }

    }
}
