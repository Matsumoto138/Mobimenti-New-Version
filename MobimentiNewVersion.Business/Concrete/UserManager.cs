using MobimentiNewVersion.Business.Abstract;
using MobimentiNewVersion.DataAccess.Abstract;
using MobimentiNewVersion.Entity.Concrete;
using System.Linq.Expressions;

namespace MobimentiNewVersion.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User entity)
        {
            _userDal.Add(entity);
        }

        public void Delete(User entity)
        {
            _userDal.Delete(entity);
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            return _userDal.Get(filter);
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return _userDal.GetAll(filter);
        }

        public User GetById(int id)
        {
            return _userDal.GetById(id);
        }

        public void Update(User entity)
        {
            _userDal.Update(entity);
        }
    }
}
