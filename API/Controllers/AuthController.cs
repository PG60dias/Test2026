using System.Security.Claims;
using Data.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] User user)
	{
		if (user.Email == "test@test.com" && user.Password == "1234")
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Email, user.Email)
			};

			var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity));

			return Ok();
		}

		return Unauthorized();
	}

	[HttpPost("logout")]
	public async Task<IActionResult> Logout()
	{
		await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		return Ok();
	}

	[HttpGet("currentuser")]
	public IActionResult GetCurrentUser()
	{
		if (User.Identity.IsAuthenticated)
		{
			return Ok(new User
			{
				Id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
				Email = User.FindFirstValue(ClaimTypes.Email)
			});
		}
		return Unauthorized();
	}
}