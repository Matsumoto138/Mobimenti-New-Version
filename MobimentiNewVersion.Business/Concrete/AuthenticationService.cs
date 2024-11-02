using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using MobimentiNewVersion.Business.Abstract;
using MobimentiNewVersion.DataAccess.Abstract;
using MobimentiNewVersion.Entity;
using MobimentiNewVersion.Entity.Concrete;
using MobimentiNewVersion.Entity.Result;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MobimentiNewVersion.Business.Concrete
{
    public class AuthenticationService : IAuthenticateService
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

		public AuthResult Authenticate(string username, string password, string role)
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

					var claims = new List<Claim>
					{
						new Claim(ClaimTypes.Name, username),
						new Claim(ClaimTypes.Role, role)
					};
					return new AuthResult { IsSuccess = true, Token= GenerateJwtToken(user) }; // Kullanıcı için JWT token üret
                }
			}
			else if (role == "Mentor")
			{
				mentor = _mentorDal.Get(m =>  m.Email == username);
                if (!mentor.IsConfirmed)
                {

					return new AuthResult { IsSuccess = false, ErrorMessage = "Henüz hesabınız onaylanmadı. Lütfen sizinle iletişime geçmemizi bekleyin" };
				}
                // Eğer Mentor bulunduysa
                else if (mentor != null && BCrypt.Net.BCrypt.Verify(password, mentor.Password))
				{
					return new AuthResult { Token = GenerateJwtToken(mentor), IsSuccess = true }; // Mentor için JWT token üret
				}
			}
			else if(role == "Admin")
			{
				admin = _adminDal.Get(a => a.Email == username);
				// Eğer Admin bulunduysa
				if (admin != null && BCrypt.Net.BCrypt.Verify(password, admin.Password))
				{
					return new AuthResult { Token = GenerateJwtToken(admin), IsSuccess = true }; // Admin için JWT token üret
				}
			}

			// Hiçbiri bulunmadıysa
			return new AuthResult { IsSuccess = false, ErrorMessage = "Kullanıcı adı veya şifre yanlış." };

		}

		private string GenerateJwtToken(BaseUser user)
		{
			// JWT oluşturma işlemi
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes("DLrbMfnZY4RPB6vBlZzswVkPizKFMgTv");

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
					new Claim(ClaimTypes.Role, user.Role) // Kullanıcı rolünü ekliyoruz
				}),
				Expires = DateTime.Now.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}


		public RegisterResult Register(string firstName, string lastName, string email, string password, string role)
		{
			var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);

            if (role == "User")
            {
				var user = new User
				{
					FirstName = firstName,
					LastName = lastName,
					Email = email,
					Password = hashPassword,
					Role = role,
					CreatedDate = DateTime.Now,
				};
				_userDal.Add(user);
				return new RegisterResult { IsSuccess = true };
            }

			else if (role == "Mentor")
            {
				var mentor = new Mentor
				{
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Password = hashPassword,
                    Role = role,
                    CreatedDate = DateTime.Now,
					IsConfirmed = false,
                };
				_mentorDal.Add(mentor);
                return new RegisterResult { IsSuccess = true };
            }

			else if(role == "Admin")
			{
				var admin = new Admin
				{
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Password = hashPassword,
                    Role = role,
                    CreatedDate = DateTime.Now,
                };
				_adminDal.Add(admin);
                return new RegisterResult { IsSuccess = true };
            }
			return new RegisterResult { IsSuccess = false, ErrorMessage="Kayıt sırasında hata oluştu!" };

        }
		public void Logout()
		{
		}
	}
}
