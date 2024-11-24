using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobimentiNewVersion.Entity.Concrete
{
    public class Mentor : BaseUser
    {

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public byte[]? ProfilePicture { get; set; } = null;
        public string LinkedinAdress { get; set; } = string.Empty;
        public string School { get; set; } = string.Empty;
        public bool IsConfirmed { get; set; }
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public List<Experience> Experiences { get; set; } = new List<Experience>();
        public List<DateTime> AvailableDates { get; set; } = new List<DateTime>();
    }
}
