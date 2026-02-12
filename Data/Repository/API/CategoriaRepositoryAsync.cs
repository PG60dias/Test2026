using System.Net.Http.Json;
using System.Text.Json;
using Data.Modelo;
using Data.Repository.Common;

namespace Data.Repository.API
{
	public class CategoriaRepositoryAsync : ICategoriaRepository, ICategoriaRepositoryAsync
	{
		private readonly HttpClient _httpClient;
		private static readonly JsonSerializerOptions _options = new() { PropertyNameCaseInsensitive = true };

		public CategoriaRepositoryAsync(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		// --- MÉTODOS ASÍNCRONOS (ICategoriaRepositoryAsync) ---
		public async Task<IEnumerable<Categoria>> GetAllCategoriasAsync()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<Categoria>>("Categorias", _options) ?? new List<Categoria>();
		}

		public async Task<Categoria?> GetCategoriaAsync(int id)
		{
			return await _httpClient.GetFromJsonAsync<Categoria>($"Categorias/{id}", _options);
		}

		public async Task AddCategoriaAsync(Categoria categoria) => await _httpClient.PostAsJsonAsync("Categorias", categoria);
		public async Task UpdateCategoriaAsync(Categoria categoria) => await _httpClient.PutAsJsonAsync($"Categorias/{categoria.Id}", categoria);
		public async Task DeleteCategoriaAsync(int id) => await _httpClient.DeleteAsync($"Categorias/{id}");

		// --- MÉTODOS SÍNCRONOS (ICategoriaRepository) ---
		public IEnumerable<Categoria> GetAllCategorias() => GetAllCategoriasAsync().GetAwaiter().GetResult();
		public Categoria? GetCategoria(int id) => GetCategoriaAsync(id).GetAwaiter().GetResult();
		public void AddCategoria(Categoria categoria) => AddCategoriaAsync(categoria).GetAwaiter().GetResult();
		public void UpdateCategoria(Categoria categoria) => UpdateCategoriaAsync(categoria).GetAwaiter().GetResult();
		public void DeleteCategoria(int id) => DeleteCategoriaAsync(id).GetAwaiter().GetResult();
	}
}