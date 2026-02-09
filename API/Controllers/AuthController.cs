using System.Security.Claims;
using Data.Common; // Namespace donde está tu TestDbContext
using Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly TestDbContext _context;

	public AuthController(TestDbContext context)
	{
		_context = context;
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] Usuario loginRequest)
	{

		var user = await _context.Usuarios
			.FirstOrDefaultAsync(u => u.Email == loginRequest.Email);

		if (user != null && PasswordHasher.VerifyPassword(user.Password, loginRequest.Password))
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new Claim(ClaimTypes.Email, user.Email)
			};

			var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity));

			return Ok();
		}

		return Unauthorized();
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register([FromBody] Usuario newUser)
	{
		if (await _context.Usuarios.AnyAsync(u => u.Email == newUser.Email))
		{
			return BadRequest("El usuario ya existe.");
		}

		var userToSave = new Usuario
		{
			Email = newUser.Email,
			Password = PasswordHasher.HashPassword(newUser.Password)
		};

		_context.Usuarios.Add(userToSave);
		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpGet("currentuser")]
	public IActionResult GetCurrentUser()
	{
		if (User.Identity.IsAuthenticated)
		{
			return Ok(new Usuario
			{
				Id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
				Email = User.FindFirstValue(ClaimTypes.Email)
			});
		}
		return Unauthorized();
	}

	[HttpPost("logout")]
	public async Task<IActionResult> Logout()
	{
		await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		return Ok();
	}
}