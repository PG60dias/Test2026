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
		public bool HanCambiadoLosDatos(Cliente original, string nombre, string direccion, string email, string telefono, int categoriaId)
		{
			return original.Nombre != nombre ||
				   original.Direccion != direccion ||
				   original.Email != email ||
				   original.Telefono != telefono ||
				   original.Categoria != categoriaId;
		}

		//public void ConfirmarEdicion(Cliente original, Cliente editado)
		//{
		//	original.Nombre = editado.Nombre;
		//	original.Direccion = editado.Direccion;
		//	original.Email = editado.Email;
		//	original.Telefono = editado.Telefono;
		//	original.Categoria = editado.Categoria;

		//	original.CategoriaNavigation = editado.CategoriaNavigation;
		//	Repository.UpdateCliente(original);
		//}
	}
}
