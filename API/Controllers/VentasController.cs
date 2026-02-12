using Data.Common;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class VentasController(TestDbContext context) : ControllerBase
	{
		private readonly TestDbContext _context = context;
		private readonly Random _random = new();

		[HttpPost("generar-masivo")]
		[HttpPost("generar-masivo")]
		public async Task<IActionResult> GenerarMasivo([FromQuery] int cantidad = 10)
		{
			try
			{
				var clientes = await _context.Clientes.ToListAsync();
				var articulos = await _context.Articulos.ToListAsync();

				if (!clientes.Any() || !articulos.Any())
					return BadRequest("Faltan maestros (clientes/artículos).");

				for (int i = 0; i < cantidad; i++)
				{
					var cliente = clientes[_random.Next(clientes.Count)];

					// Lógica de fecha aleatoria
					DateTime inicio = new(2025, 1, 1);
					int rangoDias = (new DateTime(2026, 1, 31) - inicio).Days;
					DateTime fechaAleatoria = inicio.AddDays(_random.Next(rangoDias));

					// Crea la venta
					var nuevaVenta = new Venta
					{
						ClienteId = cliente.Id,
						Fecha = fechaAleatoria
					};
					_context.Ventas.Add(nuevaVenta);
					await _context.SaveChangesAsync();

					// Genera los detalles
					int productosDiferentes = _random.Next(1, 6);

					for (int j = 0; j < productosDiferentes; j++)
					{
						var articulo = articulos[_random.Next(articulos.Count)];

						// Lógica de precios
						decimal precioAplicado = articulo.PVP;
						if (cliente.Categoria == 3) precioAplicado = articulo.PVP * 0.75m;
						else if (cliente.Categoria == 1) precioAplicado = articulo.PVP * 1.10m;

						// Conecta el detalle con la venta de arriba
						var detalle = new VentaDetalle
						{
							VentaId = nuevaVenta.Id, 
							ArticuloId = articulo.Id,
							Cantidad = _random.Next(1, 6),
							PrecioAplicado = precioAplicado
						};

						_context.VentasDetalle.Add(detalle);

						articulo.PrecioUltimaVenta = precioAplicado;
						_context.Articulos.Update(articulo);
					}
				}

				await _context.SaveChangesAsync();

				return Ok(new { mensaje = $"Generadas {cantidad} ventas con múltiples productos cada una." });
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error: {ex.Message}");
			}
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
		{
			return await _context.Ventas
				.Include(v => v.Detalles)
				.OrderByDescending(v => v.Fecha)
				.ToListAsync();
		}
	}
}