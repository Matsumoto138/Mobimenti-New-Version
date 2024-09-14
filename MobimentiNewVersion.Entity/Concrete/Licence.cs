using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobimentiNewVersion.Entity.Concrete
{
    public class Licence : BaseEntity
    {
        public string LicenceKey { get; set; }
        public DateOnly ExpireDate { get; set; }

        //Foreign Key
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
