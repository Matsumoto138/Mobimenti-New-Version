using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobimentiNewVersion.Business.Abstract
{
	public interface IAuthenticationService
	{
		string Authenticate(string username, string password, string role);
		void Register(string username, string password, string role);
	}
}
