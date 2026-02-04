using Data.Modelo;

namespace Data.Repository.Common
{
    public interface IClienteRepository
    {
        Cliente? GetCliente(int id);
        IEnumerable<Cliente> GetAllClientes();
        void AddCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(int id);
		IEnumerable<Cliente> GetClientesFiltrados(List<int> categoriaIds = null, string busqueda = null);

	}
}
