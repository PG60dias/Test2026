using System.Text.Json;
using Data.Modelo;
using Data.Repository.Common;

namespace Data.Repository.API
{
    public class CategoriaRepository : ICategoriaRepository
    {
		private const string API_ENDPOINT = "http://localhost:5000/";
		public void AddCategoria(Categoria categoria)
        {
			throw new NotImplementedException();
		}

        public void DeleteCategoria(int id)
        {
			throw new NotImplementedException();
		}

		public IEnumerable<Categoria> GetAllCategorias()
		{
			using (var client = new HttpClient())
			{
				var request = new HttpRequestMessage(HttpMethod.Get, API_ENDPOINT + "Categorias");
				var response = client.Send(request);
				response.EnsureSuccessStatusCode();

				var json = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();

				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				return JsonSerializer.Deserialize<IEnumerable<Categoria>>(json, options) ?? new List<Categoria>();
			}
		}

		public Categoria? GetCategoria(int id)
        {
			throw new NotImplementedException();
		}

        public void UpdateCategoria(Categoria categoria)
        {
			throw new NotImplementedException();
		}
    }
}
