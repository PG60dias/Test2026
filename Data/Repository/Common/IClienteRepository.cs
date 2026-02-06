using Data.DTOs;
using Data.Modelo;

namespace Data.Repository.Common
{
    public interface IClienteRepository
    {
        Cliente? GetCliente(int id);
        IEnumerable<ClienteDTO> GetAllClientes();
        void AddCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(int id);
		IEnumerable<ClienteDTO> GetClientesFiltrados(List<int> categoriaIds = null, string busqueda = null);

	}
}
