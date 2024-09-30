using Microsoft.IdentityModel.Tokens;
using MobimentiNewVersion.Business.Abstract;
using MobimentiNewVersion.DataAccess.Abstract;
using MobimentiNewVersion.Entity;
using MobimentiNewVersion.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MobimentiNewVersion.Business.Concrete
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly IUserDal _userDal;
		private readonly IMentorDal _mentorDal;
		private readonly IAdminDal _adminDal;

		public AuthenticationService(IUserDal userDal, IMentorDal mentorDal, IAdminDal adminDal)
		{
			_userDal = userDal;
			_mentorDal = mentorDal;
			_adminDal = adminDal;
		}

		public string Authenticate(string username, string password, string role)
		{
			User user;
			Admin admin;
			Mentor mentor;
            if (role == "User")
            {
				user = _userDal.Get(u => u.Email == username);
				// Eğer User bulunduysa
				if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
				{
					return GenerateJwtToken(user); // Kullanıcı için JWT token üret
				}
			}
			else if (role == "Mentor")
			{
				mentor = _mentorDal.Get(m =>  m.Email == username);

				// Eğer Mentor bulunduysa
				if (mentor != null && BCrypt.Net.BCrypt.Verify(password, mentor.Password))
				{
					return GenerateJwtToken(mentor); // Mentor için JWT token üret
				}
			}
			else if(role == "Admin")
			{
				admin = _adminDal.Get(a => a.Email == username);
				// Eğer Admin bulunduysa
				if (admin != null && BCrypt.Net.BCrypt.Verify(password, admin.Password))
				{
					return GenerateJwtToken(admin); // Admin için JWT token üret
				}
			}

			// Hiçbiri bulunmadıysa
			throw new UnauthorizedAccessException("Kullanıcı adı veya şifre yanlış.");

		}

		private string GenerateJwtToken(BaseUser user)
		{
			// JWT oluşturma işlemi
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes("your_secret_key_here");

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
			new Claim(ClaimTypes.Name, user.Email),
			new Claim(ClaimTypes.Role, user.Role) // Kullanıcı rolünü ekliyoruz
				}),
				Expires = DateTime.UtcNow.AddHours(1),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}


		public void Register(string username, string password, string role)
		{
			var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);

            if (role == "User")
            {
				var user = new User
				{
					Email = username,
					Password = hashPassword,
					Role = role
				};
				_userDal.Add(user);
            }

			else if (role == "Mentor")
            {
				var mentor = new Mentor
				{ 
					Email = username, 
					Password = hashPassword,
					Role = role
				};
				_mentorDal.Add(mentor);
            }

			else if(role == "Admin")
			{
				var admin = new Admin
				{
					Email = username,
					Password = hashPassword,
					Role = role
				};
				_adminDal.Add(admin);
			}

        }
	}
}
