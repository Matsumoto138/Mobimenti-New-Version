using Microsoft.AspNetCore.Components.Authorization;
using MobimentiNewVersion.Business.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MobimentiNewVersion.Business.Concrete
{
	public class CustomAuthenticationStateProvider : AuthenticationStateProvider
	{
		private readonly IAuthenticateService _authService;
		private string _jwtToken;

		public CustomAuthenticationStateProvider(IAuthenticateService authService)
		{
			_authService = authService;
		}

		public override Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			
			if (string.IsNullOrEmpty(_jwtToken))
			{
				var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
				return Task.FromResult(new AuthenticationState(anonymous));
			}

			// Kullanıcı giriş yapmışsa, token kullanılarak kimlik doğrulaması yapılır
			var claims = new JwtSecurityTokenHandler().ReadJwtToken(_jwtToken).Claims;
			var identity = new ClaimsIdentity(claims, "accessToken");
			var user = new ClaimsPrincipal(identity);

			return Task.FromResult(new AuthenticationState(user));
		}

		public void MarkUserAsAuthenticated(string jwtToken)
		{
			_jwtToken = jwtToken;
			var claims = new JwtSecurityTokenHandler().ReadJwtToken(jwtToken).Claims;
			var identity = new ClaimsIdentity(claims, "accessToken");
			var user = new ClaimsPrincipal(identity);

			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
		}

		public void MarkUserAsLoggedOut()
		{
			_jwtToken = null;
			var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
		}
	}
}
