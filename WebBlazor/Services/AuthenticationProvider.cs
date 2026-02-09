using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Data.Models;
using System.Net.Http.Json;

namespace WebBlazor.Services
{
	public class AuthenticationProvider : AuthenticationStateProvider
	{
		private readonly HttpClient _httpClient;

		public AuthenticationProvider(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			try
			{
				
				var user = await _httpClient.GetFromJsonAsync<User>("api/auth/currentuser");

				if (user != null && !string.IsNullOrEmpty(user.Email))
				{
					var claims = new List<Claim>
					{
						new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
						new Claim(ClaimTypes.Email, user.Email)
					};
					var identity = new ClaimsIdentity(claims, "Cookies");
					return new AuthenticationState(new ClaimsPrincipal(identity));
				}
			}
			catch { }

			return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
		}

		public void NotifyAuthenticationStateChanged()
		{
			NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
		}
	}
}