
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace WebBlazor.Services
{
	public class AuthenticationProvider : AuthenticationStateProvider
	{
		public override Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var identity = new ClaimsIdentity();
			var user = new ClaimsPrincipal(identity);
			return Task.FromResult(new AuthenticationState(user));
		}

		public void NotifyUserAuthentication(string email)
		{
			var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "apiauth_type");
			var user = new ClaimsPrincipal(identity);
			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
		}
	}
}