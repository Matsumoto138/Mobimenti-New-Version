using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobimentiNewVersion.Entity.Concrete
{
    public class Mentor : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public byte[]? ProfilePicture { get; set; } = null;
        public string LinkedinAdress { get; set; } = string.Empty;
        public string School { get; set; } = string.Empty;
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<Experience> Experiences { get; set; } = new List<Experience>();
        public ICollection<DateTime> AvailableDates { get; set; } = new List<DateTime>();
    }
}
