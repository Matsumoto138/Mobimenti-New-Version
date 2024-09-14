using MobimentiNewVersion.DataAccess.Abstract;
using MobimentiNewVersion.DataAccess.Context;
using System.Linq.Expressions;

namespace MobimentiNewVersion.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            var value = _context.Set<T>().Find(entity);
            _context.Set<T>().Remove(value);
            _context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().FirstOrDefault(filter);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
