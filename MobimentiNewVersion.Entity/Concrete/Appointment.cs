using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobimentiNewVersion.Entity.Concrete
{
    public class Appointment:BaseEntity
    {
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }

        //Foreign Keys
        public int UserId { get; set; }
        public User User { get; set; }

        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }
    }
}
