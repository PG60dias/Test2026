using System.Net.Http.Json;
using System.Text.Json;
using Data.Modelo;
using Data.Repository.Common;

namespace Data.Repository.API
{
	public class CategoriaRepositoryAsync : ICategoriaRepositoryAsync
	{
		private readonly HttpClient _httpClient;
		private static readonly JsonSerializerOptions _options = new() { PropertyNameCaseInsensitive = true };

		public CategoriaRepositoryAsync(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<Categoria>> GetAllCategoriasAsync()
		{
			// Asume que tu API tiene el endpoint "api/Categorias" o similar
			return await _httpClient.GetFromJsonAsync<IEnumerable<Categoria>>("Categorias", _options) ?? new List<Categoria>();
		}

		public async Task<Categoria?> GetCategoriaAsync(int id)
		{
			return await _httpClient.GetFromJsonAsync<Categoria>($"Categorias/{id}", _options);
		}

		public async Task AddCategoriaAsync(Categoria categoria)
		{
			await _httpClient.PostAsJsonAsync("Categorias", categoria);
		}

		public async Task UpdateCategoriaAsync(Categoria categoria)
		{
			await _httpClient.PutAsJsonAsync($"Categorias/{categoria.Id}", categoria);
		}

		public async Task DeleteCategoriaAsync(int id)
		{
			await _httpClient.DeleteAsync($"Categorias/{id}");
		}
	}
}