using Data.Modelo;
using Data.Repository.Common;


namespace Domain.Services
{
    public class ClienteService(IClienteRepository repository)
    {

        public IClienteRepository Repository = repository;

        public static void UpdateNombre(Cliente cliente)
        {
            cliente.Nombre = cliente.Nombre.ToUpper();
        }

		public IEnumerable<Cliente> FiltrarClientes(string texto)
		{
			if (string.IsNullOrWhiteSpace(texto))
				return Repository.GetAllClientes();

			return Repository.GetClientesFiltrados(texto);
		}
	}
}
