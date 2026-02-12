using System.Net.Http.Json;
using System.Text.Json;
using Data.DTOs;
using Data.Modelo;
using Data.Repository.Common;

namespace Data.Repository.API
{
	public class ClienteRepositoryAsync : IClienteRepository, IClienteRepositoryAsync
	{
		private readonly HttpClient _httpClient;
		private static readonly JsonSerializerOptions _options = new() { PropertyNameCaseInsensitive = true };

		public ClienteRepositoryAsync(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		// --- MÉTODOS ASÍNCRONOS (IClienteRepositoryAsync) ---

		public async Task<IEnumerable<ClienteDTO>> GetAllClientesAsync()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<ClienteDTO>>("Clientes", _options) ?? new List<ClienteDTO>();
		}

		public async Task<Cliente?> GetClienteAsync(int id)
		{
			return await _httpClient.GetFromJsonAsync<Cliente>($"Clientes/{id}", _options);
		}

		public async Task<IEnumerable<ClienteDTO>> GetClientesFiltradosAsync(List<int> categoriaIds = null, string busqueda = null)
		{
			var clientes = await GetAllClientesAsync();
			var consulta = clientes.AsQueryable();

			if (categoriaIds?.Any() == true)
				consulta = consulta.Where(c => c.Categoria.HasValue && categoriaIds.Contains(c.Categoria.Value));

			if (!string.IsNullOrWhiteSpace(busqueda))
			{
				consulta = consulta.Where(c =>
					(c.Nombre != null && c.Nombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase)) ||
					(c.Email != null && c.Email.Contains(busqueda, StringComparison.OrdinalIgnoreCase)) ||
					c.Id.ToString().Contains(busqueda)
				);
			}

			return consulta.ToList();
		}

		public async Task AddClienteAsync(Cliente cliente) => await _httpClient.PostAsJsonAsync("Clientes", cliente);
		public async Task UpdateClienteAsync(Cliente cliente) => await _httpClient.PutAsJsonAsync($"Clientes/{cliente.Id}", cliente);
		public async Task DeleteClienteAsync(int id) => await _httpClient.DeleteAsync($"Clientes/{id}");


		public IEnumerable<ClienteDTO> GetAllClientes()
			=> GetAllClientesAsync().GetAwaiter().GetResult();

		public Cliente? GetCliente(int id)
			=> GetClienteAsync(id).GetAwaiter().GetResult();

		public void AddCliente(Cliente cliente)
			=> AddClienteAsync(cliente).GetAwaiter().GetResult();

		public void UpdateCliente(Cliente cliente)
			=> UpdateClienteAsync(cliente).GetAwaiter().GetResult();

		public void DeleteCliente(int id)
			=> DeleteClienteAsync(id).GetAwaiter().GetResult();

		public IEnumerable<ClienteDTO> GetClientesFiltrados(List<int> categoriaIds = null, string busqueda = null)
			=> GetClientesFiltradosAsync(categoriaIds, busqueda).GetAwaiter().GetResult();
	}
}