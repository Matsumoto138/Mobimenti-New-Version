using MobimentiNewVersion.Entity.Result;

namespace MobimentiNewVersion.Business.Abstract
{
	public interface IAuthenticateService
	{
		AuthResult Authenticate(string username, string password, string role);
		RegisterResult Register(string firstName, string lastName, string email, string password, string role);
	}
}
