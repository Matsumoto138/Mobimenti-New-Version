using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobimentiNewVersion.Entity.Concrete
{
    public class Sale : BaseEntity
    {
        public DateTime SaleDate { get; set; }

        //Foreign Key
        public int UserId { get; set; }
        public User User { get; set; }

        public int PackageId { get; set; }
        public Package Package { get; set; }
    }
}
