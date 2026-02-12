using Data.DTOs;
using Data.Modelo;

namespace Data.Repository.Common
{
	public interface IClienteRepositoryAsync
	{
		Task<IEnumerable<ClienteDTO>> GetAllClientesAsync();
		Task<Cliente?> GetClienteAsync(int id);
		Task<IEnumerable<ClienteDTO>> GetClientesFiltradosAsync(List<int> categoriaIds = null, string busqueda = null);
		Task AddClienteAsync(Cliente cliente);
		Task UpdateClienteAsync(Cliente cliente);
		Task DeleteClienteAsync(int id);
	}
}