using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Data.Models;

namespace WebBlazor.Controllers
{
	[Route("account")]
	public class AccountController : Controller
	{
		private readonly HttpClient _httpClient;

		public AccountController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromForm] string email, [FromForm] string password)
		{
			var loginRequest = new Usuario { Email = email, Password = password };

			// Llamam a la API (localhost:5000) para validar
			var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginRequest);

			if (response.IsSuccessStatusCode)
			{
				var user = await response.Content.ReadFromJsonAsync<Usuario>();

				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
					new Claim(ClaimTypes.Email, user.Email)
				};

				var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

				// IMPORTANTE: Blazor crea la cookie en su propio contexto
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
					new ClaimsPrincipal(claimsIdentity));

				return Redirect("/home");
			}

			return Redirect("/?error=true");
		}

		[HttpGet("logout")]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return Redirect("/");
		}
	}
}