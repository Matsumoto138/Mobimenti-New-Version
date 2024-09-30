using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobimentiNewVersion.Entity
{
	public class BaseUser
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
	}
}
