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
		public async Task<IActionResult> GenerarMasivo([FromQuery] int cantidad = 10)
		{
			// Usamos una transacción para que se guarde TODO o NADA
			using var transaction = await _context.Database.BeginTransactionAsync();
			try
			{
				var clientes = await _context.Clientes.ToListAsync();
				var articulos = await _context.Articulos.ToListAsync();

				if (!clientes.Any() || !articulos.Any())
					return BadRequest("Faltan maestros (clientes/artículos).");

				for (int i = 0; i < cantidad; i++)
				{
					var cliente = clientes[_random.Next(clientes.Count)];

					DateTime inicio = new(2025, 1, 1);
					int rangoDias = (DateTime.Today - inicio).Days;
					DateTime fechaAleatoria = inicio.AddDays(_random.Next(rangoDias));

					var nuevaVenta = new Venta
					{
						ClienteId = cliente.Id,
						Fecha = fechaAleatoria,
						Detalles = new List<VentaDetalle>() // Inicializamos la lista
					};

					int productosDiferentes = _random.Next(1, 6);

					for (int j = 0; j < productosDiferentes; j++)
					{
						var articulo = articulos[_random.Next(articulos.Count)];

						decimal precioAplicado = articulo.PVP;
						if (cliente.Categoria == 3) precioAplicado = articulo.PVP * 0.75m;
						else if (cliente.Categoria == 1) precioAplicado = articulo.PVP * 1.10m;

						// Agregamos el detalle directamente a la colección de la venta
						nuevaVenta.Detalles.Add(new VentaDetalle
						{
							ArticuloId = articulo.Id,
							Cantidad = _random.Next(1, 6),
							PrecioAplicado = precioAplicado
						});

						articulo.PrecioUltimaVenta = precioAplicado;
					}

					_context.Ventas.Add(nuevaVenta);
				}

				// Un solo SaveChanges para todas las ventas y detalles
				await _context.SaveChangesAsync();

				// Confirmamos los cambios en SQL
				await transaction.CommitAsync();

				return Ok(new { mensaje = $"Generadas {cantidad} ventas correctamente." });
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				// Logueamos el error interno para saber por qué SQL rechaza los datos
				var innerError = ex.InnerException?.Message ?? ex.Message;
				return StatusCode(500, $"Error en SQL: {innerError}");
			}
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
		{
			return await _context.Ventas
				.Include(v => v.Detalles) // Carga los detalles
				.ThenInclude(d => d.Articulo) // Carga el nombre del producto
				.OrderByDescending(v => v.Fecha)
				.ToListAsync();
		}
	}
}