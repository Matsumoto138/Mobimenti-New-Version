using MobimentiNewVersion.Business.Abstract;
using MobimentiNewVersion.DataAccess.Abstract;
using MobimentiNewVersion.Entity.Concrete;
using System.Linq.Expressions;

namespace MobimentiNewVersion.Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Add(Admin entity)
        {
            _adminDal.Add(entity);
        }

        public void Delete(Admin entity)
        {
            _adminDal.Delete(entity);
        }

        public Admin Get(Expression<Func<Admin, bool>> filter)
        {
            return _adminDal.Get(filter);
        }

        public List<Admin> GetAll(Expression<Func<Admin, bool>> filter = null)
        {
            return _adminDal.GetAll(filter);
        }

        public Admin GetById(int id)
        {
            return _adminDal.GetById(id);
        }

        public void Update(Admin entity)
        {
            _adminDal.Update(entity);
        }
    }
}
