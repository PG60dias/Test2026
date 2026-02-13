using Data.Models;
using Data.Common;
using Microsoft.EntityFrameworkCore;
using Domain.Services.Precios;

namespace Domain.Services
{
	public class VentaService
	{
		private readonly TestDbContext _context;
		private readonly Random _random = new();

		public VentaService(TestDbContext context)
		{
			_context = context;
		}

		public async Task GenerarVentasAleatoriasAsync(int cantidad)
		{
			using var transaction = await _context.Database.BeginTransactionAsync();
			try
			{
				var clientes = await _context.Clientes.AsNoTracking().ToListAsync();
				var articulos = await _context.Articulos.ToListAsync();

				if (!clientes.Any() || !articulos.Any()) return;

				for (int i = 0; i < cantidad; i++)
				{
					var cliente = clientes[_random.Next(clientes.Count)];

					var nuevaVenta = new Venta
					{
						ClienteId = cliente.Id,
						Fecha = DateTime.Now.AddDays(-_random.Next(0, 365)),
						Detalles = new List<VentaDetalle>()
					};

					int tiposArticulos = _random.Next(1, 6);
					for (int j = 0; j < tiposArticulos; j++)
					{ 
						var articulo = articulos[_random.Next(articulos.Count)];
						var precioCat = PrecioCategorias.ObtenerPrecioCat(cliente.Categoria);
						decimal precioFinal = precioCat.Calcular(articulo.PVP);
						nuevaVenta.Detalles.Add(new VentaDetalle
						{
							ArticuloId = articulo.Id,
							Cantidad = _random.Next(1, 6),
							PrecioAplicado = precioFinal
						});
					}
					_context.Ventas.Add(nuevaVenta);
				}

				await _context.SaveChangesAsync();
				await transaction.CommitAsync();
			}
			catch
			{
				await transaction.RollbackAsync();
				throw;
			}
		}
	}
}