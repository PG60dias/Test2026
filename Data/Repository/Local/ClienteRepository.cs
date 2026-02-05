using Data.DTOs;
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

		private static ClienteDTO MapToDto(Cliente c)
		{
			return new ClienteDTO
			{
				Id = c.Id,
				Nombre = c.Nombre,
				Direccion = c.Direccion,
				Email = c.Email,
				Telefono = c.Telefono,
				Categoria = c.Categoria,
				CategoriaNombre = c.Categoria switch
				{
					1 => "Standard",
					2 => "Premium",
					3 => "Prueba",
					_ => "Sin Categoría"
				}
			};
		}

		public ClienteDTO? GetCliente(int id)
		{
			var cliente = _clientes.FirstOrDefault(c => c.Id == id);
			return cliente != null ? MapToDto(cliente) : null;
		}

		public IEnumerable<ClienteDTO> GetAllClientes()
		{
			return _clientes.Select(MapToDto).ToList();
		}

		public void AddCliente(ClienteDTO dto)
		{
			var nuevoCliente = new Cliente
			{
				Id = _clientes.Any() ? _clientes.Max(c => c.Id) + 1 : 1,
				Nombre = dto.Nombre ?? "",
				Email = dto.Email,
				Direccion = dto.Direccion,
				Telefono = dto.Telefono,
				Categoria = dto.Categoria
			};

			_clientes.Add(nuevoCliente);


			dto.Id = nuevoCliente.Id;
		}

		public void UpdateCliente(ClienteDTO dto)
		{
			var actual = _clientes.FirstOrDefault(c => c.Id == dto.Id);
			if (actual != null)
			{
				actual.Nombre = dto.Nombre ?? "";
				actual.Email = dto.Email;
				actual.Direccion = dto.Direccion;
				actual.Telefono = dto.Telefono;
				actual.Categoria = dto.Categoria;
			}
		}

		public void DeleteCliente(int id)
		{
			var c = _clientes.FirstOrDefault(x => x.Id == id);
			if (c != null)
			{
				_clientes.Remove(c);
			}
		}

		public IEnumerable<ClienteDTO> GetClientesFiltrados(List<int> categoriaIds = null, string busqueda = null)
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

			return query.Select(MapToDto).ToList();
		}
	}
}