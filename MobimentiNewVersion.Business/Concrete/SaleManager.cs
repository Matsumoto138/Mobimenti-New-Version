using MobimentiNewVersion.Business.Abstract;
using MobimentiNewVersion.DataAccess.Abstract;
using MobimentiNewVersion.Entity.Concrete;
using System.Linq.Expressions;

namespace MobimentiNewVersion.Business.Concrete
{
    public class SaleManager : ISaleService
    {
        private readonly ISaleDal _saleDal;

        public SaleManager(ISaleDal saleDal)
        {
            _saleDal = saleDal;
        }

        public void Add(Sale entity)
        {
            _saleDal.Add(entity);
        }

        public void Delete(Sale entity)
        {
            _saleDal.Delete(entity);
        }

        public Sale Get(Expression<Func<Sale, bool>> filter)
        {
            return _saleDal.Get(filter);
        }

        public List<Sale> GetAll(Expression<Func<Sale, bool>> filter = null)
        {
            return _saleDal.GetAll(filter);
        }

        public Sale GetById(int id)
        {
            return _saleDal.GetById(id);
        }

        public void Update(Sale entity)
        {
            _saleDal.Update(entity);
        }
    }
}
