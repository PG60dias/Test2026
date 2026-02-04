using Data.Modelo;
using Data.Repository.Common;
using System.Collections.ObjectModel;

namespace Data.Repository.Local
{
	public class ClienteRepository : IClienteRepository
	{
		private ObservableCollection<Cliente> _clientes =
		[
			new Cliente { Id = 1, Nombre = "Cliente Uno", Email = "uno@test.com", Direccion = "Calle 1", Telefono = "111", Categoria = 1 },
			new Cliente { Id = 2, Nombre = "Cliente Dos", Email = "dos@test.com", Direccion = "Calle 2", Telefono = "222", Categoria = 2 },
			new Cliente { Id = 3, Nombre = "Cliente Tres", Email = "tres@test.com", Direccion = "Calle 3", Telefono = "333", Categoria = 3 }
		];

		public Cliente? GetCliente(int id)
		{
			return _clientes.FirstOrDefault(c => c.Id == id);
		}

		public IEnumerable<Cliente> GetAllClientes()
		{
			return [.. _clientes];
		}

		public void AddCliente(Cliente cliente)
		{
			if (_clientes.Count > 0)
				cliente.Id = _clientes.Max(c => c.Id) + 1;
			else
				cliente.Id = 1;

			_clientes.Add(cliente);
		}

		public void UpdateCliente(Cliente cliente)
		{
			var c = GetCliente(cliente.Id);
			if (c != null)
			{
				c.Nombre = cliente.Nombre;
				c.Email = cliente.Email;
				c.Direccion = cliente.Direccion;
				c.Telefono = cliente.Telefono;
				c.Categoria = cliente.Categoria;
			}
		}

		public void DeleteCliente(int id)
		{
			var c = GetCliente(id);
			if (c != null)
			{
				_clientes.Remove(c);
			}
		}

		public IEnumerable<Cliente> GetClientesFiltrados(List<int> categoriaIds = null, string busqueda = null)
		{
			var query = _clientes.AsEnumerable();

			if (categoriaIds != null && categoriaIds.Any())
			{
				query = query.Where(c => categoriaIds.Contains(c.Categoria ?? 0));
			}

			if (!string.IsNullOrWhiteSpace(busqueda))
			{
				string b = busqueda.ToLower();
				query = query.Where(c =>
					c.Id.ToString().Contains(b) ||
					(c.Nombre != null && c.Nombre.ToLower().Contains(b)) ||
					(c.Email != null && c.Email.ToLower().Contains(b)) ||
					(c.Telefono != null && c.Telefono.Contains(b)) ||
					(c.Direccion != null && c.Direccion.ToLower().Contains(b))
				);
			}

			return query.ToList();
		}
	}
}