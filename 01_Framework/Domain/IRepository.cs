using System.Linq.Expressions;

namespace _01_Framework.Domain
{
    public interface IRepository<TKey, T> where T:class
    {
        void Create(T entity);
        T? Get(TKey key);
        T? GetBy(Expression<Func<T>> expression);
        List<T> GetAll();
        bool IsExist(Expression<Func<T, bool>> expression);
        void SaveChange();

    }
}
