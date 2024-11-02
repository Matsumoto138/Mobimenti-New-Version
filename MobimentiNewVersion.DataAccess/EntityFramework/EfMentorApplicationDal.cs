using MobimentiNewVersion.DataAccess.Abstract;
using MobimentiNewVersion.DataAccess.Context;
using MobimentiNewVersion.DataAccess.Repositories;
using MobimentiNewVersion.Entity.Concrete;


namespace MobimentiNewVersion.DataAccess.EntityFramework
{
    public class EfMentorApplicationDal : GenericRepository<MentorApplication>, IMentorApplicationDal
    {
        public EfMentorApplicationDal(AppDbContext context) : base(context)
        {
        }
    }
}
