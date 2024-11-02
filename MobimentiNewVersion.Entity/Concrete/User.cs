using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobimentiNewVersion.Entity.Concrete
{
    public class User : BaseUser
    {
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

        //Foreign Key

        public int? LicenceId { get; set; }
        public Licence Licence { get; set; }

        public List<Sale> Sales { get; set; }
    }
}
