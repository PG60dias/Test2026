using System.Net;
using System.Text.Json;
using Data.Modelo;
using Data.Repository.Common;

namespace Data.Repository.API
{
    public  class ClienteRepository : IClienteRepository
    {
        private const string API_ENDPOINT = "http://localhost:5000/";

        public void AddCliente(Cliente cliente)
        {
			throw new NotImplementedException();
		}

        public void DeleteCliente(int id)
        {
			var client = new HttpClient();
			var request = new HttpRequestMessage(HttpMethod.Delete, API_ENDPOINT + "Clientes/" + id);
			var response = client.Send(request);
			response.EnsureSuccessStatusCode();

		}

        public IEnumerable<Cliente> GetAllClientes()
        {
			var client = new HttpClient();
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
			var request = new HttpRequestMessage(HttpMethod.Get, API_ENDPOINT + "Clientes");
			var response = client.Send(request);
			response.EnsureSuccessStatusCode();
			var json = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();

            return JsonSerializer.Deserialize<IEnumerable<Cliente>>(json, options);

		}

		public Cliente? GetCliente(int id)
        {
            throw new NotImplementedException();
		}

        public IEnumerable<Cliente> GetClientesFiltrados(List<int> categoriaIds = null, string busqueda = null)
        {
			throw new NotImplementedException();
		}

        public void UpdateCliente(Cliente cliente)
        {
			throw new NotImplementedException();
		}
    }
}
