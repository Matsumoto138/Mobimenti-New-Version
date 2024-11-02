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
    public class MentorApplicationManager : IMentorApplicationService
    {
        private readonly IMentorApplicationDal _applicationDal;

        public MentorApplicationManager(IMentorApplicationDal applicationDal)
        {
            _applicationDal = applicationDal;
        }

        public void Add(MentorApplication entity)
        {
            _applicationDal.Add(entity);
        }

        public void Delete(MentorApplication entity)
        {
            _applicationDal.Delete(entity);
        }

        public MentorApplication Get(Expression<Func<MentorApplication, bool>> filter)
        {
            return _applicationDal.Get(filter);
        }

        public List<MentorApplication> GetAll(Expression<Func<MentorApplication, bool>> filter = null)
        {
            return _applicationDal.GetAll(filter);
        }

        public MentorApplication GetById(int id)
        {
            return _applicationDal.GetById(id);
        }

        public void Update(MentorApplication entity)
        {
            _applicationDal.Update(entity);
        }
    }
}
