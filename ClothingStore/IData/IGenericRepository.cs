using System.Linq.Expressions;

namespace IData
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<U> GetAll<U>() where U : class;
        IEnumerable<U> GetAll<U>(Func<U, bool> predicate, List<string> includes = null) where U : class;
        T? Insert(T entity);
        T? Update(T entity);
        T Get(Expression<Func<T, bool>> searchCondition, List<string> includes = null);
        void Delete(T entity);
        bool CheckConnection();
    }
}

