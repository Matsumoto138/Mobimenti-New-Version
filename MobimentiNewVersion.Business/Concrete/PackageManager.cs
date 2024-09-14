using MobimentiNewVersion.Business.Abstract;
using MobimentiNewVersion.DataAccess.Abstract;
using MobimentiNewVersion.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobimentiNewVersion.Business.Concrete
{
    public class PackageManager : IPackageService
    {
        private readonly IPackageDal _packageDal;

        public PackageManager(IPackageDal packageDal)
        {
            _packageDal = packageDal;
        }

        public void Add(Package entity)
        {
            _packageDal.Add(entity);
        }

        public void Delete(Package entity)
        {
            _packageDal.Delete(entity);
        }

        public Package Get(Expression<Func<Package, bool>> filter)
        {
            return _packageDal.Get(filter);
        }

        public List<Package> GetAll(Expression<Func<Package, bool>> filter = null)
        {
            return _packageDal.GetAll(filter);
        }

        public Package GetById(int id)
        {
            return _packageDal.GetById(id);
        }

        public void Update(Package entity)
        {
            _packageDal.Update(entity);
        }
    }
}
