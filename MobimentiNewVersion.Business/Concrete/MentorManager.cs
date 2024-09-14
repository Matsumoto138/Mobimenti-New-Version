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
    public class MentorManager : IMentorService
    {
        private readonly IMentorDal _mentorDal;

        public MentorManager(IMentorDal mentorDal)
        {
            _mentorDal = mentorDal;
        }

        public void Add(Mentor entity)
        {
            _mentorDal.Add(entity);
        }

        public void Delete(Mentor entity)
        {
            _mentorDal.Delete(entity);
        }

        public Mentor Get(Expression<Func<Mentor, bool>> filter)
        {
            return _mentorDal.Get(filter);
        }

        public List<Mentor> GetAll(Expression<Func<Mentor, bool>> filter = null)
        {
            return _mentorDal.GetAll(filter);
        }

        public Mentor GetById(int id)
        {
            return _mentorDal.GetById(id);
        }

        public void Update(Mentor entity)
        {
            _mentorDal.Update(entity);
        }
    }
}
