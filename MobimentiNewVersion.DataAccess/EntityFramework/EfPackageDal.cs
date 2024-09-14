using MobimentiNewVersion.DataAccess.Abstract;
using MobimentiNewVersion.DataAccess.Context;
using MobimentiNewVersion.DataAccess.Repositories;
using MobimentiNewVersion.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobimentiNewVersion.DataAccess.EntityFramework
{
    public class EfPackageDal : GenericRepository<Package>, IPackageDal
    {
        public EfPackageDal(AppDbContext context) : base(context)
        {
        }
    }
}
