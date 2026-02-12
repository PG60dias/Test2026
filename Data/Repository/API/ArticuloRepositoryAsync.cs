using Data.Models;
using Data.Modelo;
using Data.Repository.Common;
using System.Net.Http.Json;

namespace Data.Repository.API
{

	public class ArticuloRepositoryAsync : IArticuloRepository
	{
		private readonly HttpClient _http;

		public ArticuloRepositoryAsync(HttpClient http)
		{
			_http = http;
		}

		public async Task<IEnumerable<Articulo>> GetArticulosAsync()
		{
			return await _http.GetFromJsonAsync<IEnumerable<Articulo>>("Articulos") ?? new List<Articulo>();
		}

		public async Task<IEnumerable<CategoriaProducto>> GetCategoriasProductosAsync()
		{
			return await _http.GetFromJsonAsync<IEnumerable<CategoriaProducto>>("CategoriasProductos") ?? new List<CategoriaProducto>();
		}

		public async Task GenerarVentasMasivasAsync(int cantidad)
		{
			await _http.PostAsync($"Ventas/generar-masivo?cantidad={cantidad}", null);
		}

		public async Task<IEnumerable<Venta>> GetVentasAsync()
		{
			return await _http.GetFromJsonAsync<IEnumerable<Venta>>("Ventas") ?? new List<Venta>();
		}

        public Task LimpiarVentasAsync()
        {
            throw new NotImplementedException();
        }
    }
}