using Data.DTOs;
using Data.Repository.Common;


namespace Domain.Services
{
    public class ClienteService(IClienteRepository repository)
    {

        public IClienteRepository Repository = repository;

        public static void UpdateNombre(ClienteDTO cliente)
        {
            cliente.Nombre = cliente.Nombre.ToUpper();
        }
		public bool HanCambiadoLosDatos(ClienteDTO original, string nombre, string direccion, string email, string telefono, int categoriaId)
		{
			return original.Nombre != nombre ||
				   original.Direccion != direccion ||
				   original.Email != email ||
				   original.Telefono != telefono ||
				   original.Categoria != categoriaId;
		}

		public IEnumerable<ClienteDTO> GetClientesFiltrados(List<int> categoriaIds = null, string busqueda = null)
		{
			return Repository.GetClientesFiltrados(categoriaIds, busqueda?.Trim());
		}
	}
}
