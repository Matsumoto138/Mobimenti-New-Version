using MobimentiNewVersion.Business.Abstract;
using MobimentiNewVersion.DataAccess.Abstract;
using MobimentiNewVersion.Entity.Concrete;
using System.Linq.Expressions;

namespace MobimentiNewVersion.Business.Concrete
{
    public class LicenceManager : ILicenceService
    {
        private readonly ILicenceDal _licenceDal;

        public LicenceManager(ILicenceDal licenceDal)
        {
            _licenceDal = licenceDal;
        }

        public void Add(Licence entity)
        {
            _licenceDal.Add(entity);
        }

        public void Delete(Licence entity)
        {
            _licenceDal.Delete(entity);
        }

        public Licence Get(Expression<Func<Licence, bool>> filter)
        {
            return _licenceDal.Get(filter);
        }

        public List<Licence> GetAll(Expression<Func<Licence, bool>> filter = null)
        {
            return _licenceDal.GetAll(filter);
        }

        public Licence GetById(int id)
        {
            return _licenceDal.GetById(id);
        }

        public void Update(Licence entity)
        {
            _licenceDal.Update(entity);
        }
    }
}
