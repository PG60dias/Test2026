using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using System.Security.Claims;

namespace WebBlazor.Services
{
	public class AuthenticationProvider : ServerAuthenticationStateProvider
	{
		public override Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			return base.GetAuthenticationStateAsync();
		}

		public void NotifyAuthenticationStateChanged()
		{
			NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
		}
	}
}