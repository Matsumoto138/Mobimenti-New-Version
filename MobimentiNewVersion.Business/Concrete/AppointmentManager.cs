using MobimentiNewVersion.Business.Abstract;
using MobimentiNewVersion.DataAccess.Abstract;
using MobimentiNewVersion.Entity.Concrete;
using System.Linq.Expressions;

namespace MobimentiNewVersion.Business.Concrete
{
    public class AppointmentManager : IAppointmentService
    {
        private readonly IAppointmentDal _appointmentDal;

        public AppointmentManager(IAppointmentDal appointmentDal)
        {
            _appointmentDal = appointmentDal;
        }

        public void Add(Appointment entity)
        {
            _appointmentDal.Add(entity);
        }

        public void Delete(Appointment entity)
        {
            _appointmentDal.Delete(entity);
        }

        public Appointment Get(Expression<Func<Appointment, bool>> filter)
        {
            return _appointmentDal.Get(filter);
        }

        public List<Appointment> GetAll(Expression<Func<Appointment, bool>> filter = null)
        {
            return _appointmentDal.GetAll(filter);
        }

        public Appointment GetById(int id)
        {
            return _appointmentDal.GetById(id);
        }

        public void Update(Appointment entity)
        {
            _appointmentDal.Update(entity);
        }
    }
}
