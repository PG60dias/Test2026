using Data.Common;
using Data.DTOs;
using Data.Modelo;
using Data.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.EF
{
    public class ClienteRepository(TestDbContext context) : IClienteRepository
    {
		private static ClienteDTO MapToDto(Cliente c) => new ClienteDTO
		{
			Id = c.Id,
			Nombre = c.Nombre,
			Direccion = c.Direccion,
			Email = c.Email,
			Telefono = c.Telefono,
			Categoria = c.Categoria,
			CategoriaNombre = c.CategoriaNavigation?.Nombre ?? "Sin Categoría"
		};

		public IEnumerable<ClienteDTO> GetAllClientes()
		{
			return context.Clientes.Include(c => c.CategoriaNavigation)
						  .Select(c => MapToDto(c)).ToList();
		}

		public ClienteDTO? GetCliente(int id)
		{
			var c = context.Clientes.Include(n => n.CategoriaNavigation).FirstOrDefault(x => x.Id == id);
			return c != null ? MapToDto(c) : null;
		}

		public void AddCliente(ClienteDTO dto)
		{
			var entidad = new Cliente
			{
				Nombre = dto.Nombre ?? "",
				Direccion = dto.Direccion,
				Email = dto.Email,
				Telefono = dto.Telefono,
				Categoria = dto.Categoria
			};
			context.Clientes.Add(entidad);
			context.SaveChanges();
			dto.Id = entidad.Id; 
		}

		public void UpdateCliente(ClienteDTO dto)
		{
			var actual = context.Clientes.Find(dto.Id);
			if (actual != null)
			{
				actual.Nombre = dto.Nombre ?? "";
				actual.Direccion = dto.Direccion;
				actual.Email = dto.Email;
				actual.Telefono = dto.Telefono;
				actual.Categoria = dto.Categoria;
				context.Clientes.Update(actual);
				context.SaveChanges();
			}
		}
        public void DeleteCliente(int id) {
            var cliente = context.Clientes.Find(id);
            if (cliente != null)
            {
                context.Clientes.Remove(cliente);
                context.SaveChanges();
            }
        }

		public IEnumerable<ClienteDTO> GetClientesFiltrados(List<int> categoriaIds = null, string busqueda = null)
		{
			var query = context.Clientes.Include(c => c.CategoriaNavigation).AsQueryable();

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

			return query.Select(c => MapToDto(c)).ToList();
		}
    }
}
