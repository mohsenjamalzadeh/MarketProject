using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using _01_Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace _01_Framework.Infrastructure
{
    public class RepositoryBase<TKey,T>:IRepository<TKey,T> where T:class
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add(entity);
        }

        public T? Get(TKey key)
        {
            return _context.Find<T>(key);
        }

        public T? GetBy(Expression<Func<T>> expression)
        {
            return _context.Set<T>().Find(expression);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public bool IsExist(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

         
    }
}
