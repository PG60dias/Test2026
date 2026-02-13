using Data.Common;
using Data.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class VentasController : ControllerBase
{
	private readonly VentaService _ventaService;
	private readonly TestDbContext _context;

	public VentasController(VentaService ventaService, TestDbContext context)
	{
		_ventaService = ventaService;
		_context = context;
	}

	[HttpPost("generar-masivo")]
	public async Task<IActionResult> GenerarMasivo([FromQuery] int cantidad = 10)
	{
		await _ventaService.GenerarVentasAleatoriasAsync(cantidad);
		return Ok(new { mensaje = "Ventas generadas con éxito" });
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
	{
		return await _context.Ventas
			//.Include(v => v.Cliente)
			.Include(v => v.Detalles)
			.ThenInclude(d => d.Articulo)
			.OrderBy(v => v.Fecha)
			.ToListAsync();
	}
}