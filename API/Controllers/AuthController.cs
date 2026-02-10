using System.Security.Claims;
using Data.Common;
using Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Services;

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
		// Buscamos al usuario por Email
		var user = await _context.Usuarios
			.FirstOrDefaultAsync(u => u.Email == loginRequest.Email);

		// Verificamos contraseña usando el PasswordHasher existente
		if (user != null && PasswordHasher.VerifyPassword(user.Password, loginRequest.Password))
		{
			// Blazor usa estos datos para crear su propia cookie local.
			return Ok(new Usuario
			{
				Id = user.Id,
				Email = user.Email
			});
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
		// El logout real de la sesión se hace en Blazor
		return Ok();
	}
}