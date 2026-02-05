using System.Net;
using System.Text.Json;
using Data.DTOs;
using Data.Repository.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Data.Repository.API
{
    public  class ClienteRepository : IClienteRepository
    {
        private const string API_ENDPOINT = "http://localhost:5000/";
		private static readonly HttpClient _httpClient = new HttpClient();
		private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions() 
																				{ PropertyNameCaseInsensitive = true };

		public void AddCliente(ClienteDTO cliente)
        {
			var json = JsonSerializer.Serialize(cliente, _jsonSerializerOptions);
			var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
			var request = new HttpRequestMessage(HttpMethod.Post, API_ENDPOINT + "Clientes");
			request.Content = content;
			var response = _httpClient.Send(request);
			response.EnsureSuccessStatusCode();
		}

        public void DeleteCliente(int id)
        {
			var request = new HttpRequestMessage(HttpMethod.Delete, API_ENDPOINT + "Clientes/" + id);
			var response = _httpClient.Send(request);
			response.EnsureSuccessStatusCode();

		}

        public IEnumerable<ClienteDTO> GetAllClientes()
        {
			var request = new HttpRequestMessage(HttpMethod.Get, API_ENDPOINT + "Clientes");
			var response = _httpClient.Send(request);
			response.EnsureSuccessStatusCode();
			var json = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();

            return JsonSerializer.Deserialize<IEnumerable<ClienteDTO>>(json, _jsonSerializerOptions);

		}

		public ClienteDTO? GetCliente(int id)
        {
			var request = new HttpRequestMessage(HttpMethod.Get, API_ENDPOINT + "Clientes/" + id);
			var response = _httpClient.Send(request);
			response.EnsureSuccessStatusCode();
			var json = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();

			return JsonSerializer.Deserialize<ClienteDTO>(json, _jsonSerializerOptions);
		}

        public IEnumerable<ClienteDTO> GetClientesFiltrados(List<int> categoriaIds = null, string busqueda = null)
        {

			var consulta = GetAllClientes().AsQueryable();

			//Filtro checkbox categorias
			if (categoriaIds != null && categoriaIds.Any())
			{
				consulta = consulta.Where(c => c.Categoria.HasValue && categoriaIds.Contains(c.Categoria.Value));
			}

			if (!string.IsNullOrWhiteSpace(busqueda))
			{
				string b = busqueda.ToLower();

				consulta = consulta.Where(c =>
					c.Id.ToString().Contains(b) ||
					(c.Nombre != null && c.Nombre.ToLower().Contains(b)) ||
					(c.Email != null && c.Email.ToLower().Contains(b)) ||
					(c.Telefono != null && c.Telefono.Contains(b)) ||
					(c.Direccion != null && c.Direccion.ToLower().Contains(b))
				);
			}
			return consulta.ToList();
		}

		public void UpdateCliente(ClienteDTO cliente)
		{
			var json = JsonSerializer.Serialize(cliente, _jsonSerializerOptions);
			var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
			var request = new HttpRequestMessage(HttpMethod.Put, API_ENDPOINT + "Clientes/" + cliente.Id);
			request.Content = content;
			var response = _httpClient.Send(request);
			response.EnsureSuccessStatusCode();
			
		}
	}
}
