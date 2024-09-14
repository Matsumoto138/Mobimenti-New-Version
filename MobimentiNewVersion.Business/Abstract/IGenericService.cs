using System.Linq.Expressions;

namespace MobimentiNewVersion.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
