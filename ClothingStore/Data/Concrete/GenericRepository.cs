using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using IData;

namespace Data.Concrete
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbContext Context { get; set; }

        public virtual IEnumerable<U> GetAll<U>() where U : class
        {
            return Context.Set<U>().ToList();
        }

        public virtual IEnumerable<U> GetAll<U>(Func<U, bool> searchCondition, List<string> includes = null) where U : class
        {
            IQueryable<U> query = Context.Set<U>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.Where(searchCondition).Select(x => x).ToList();
        }


        public virtual T Insert(T entity)
        {
            var result=Context.Set<T>().Add(entity);
            Save();
            return result.Entity;
        }

        public T Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Save();
            return entity;
        }


        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            Save();
        }

        public bool CheckConnection()
        {
            return Context.Database.EnsureCreated();
        }

        public virtual T Get(Expression<Func<T, bool>> searchCondition, List<string> includes = null)
        {
            IQueryable<T> query = Context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.Where(searchCondition).Select(x => x)
                .FirstOrDefault();
        }

        protected void Save()
        {
            Context.SaveChanges();
        }

    }
}

