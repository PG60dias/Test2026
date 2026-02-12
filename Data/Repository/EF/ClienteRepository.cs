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
			return context.Clientes.Include(c => c.CategoriaNavigation).AsNoTracking()
						  .Select(c => MapToDto(c)).ToList();
		}

		public Cliente? GetCliente(int id)
		{
			return context.Clientes.Include(n => n.CategoriaNavigation).FirstOrDefault(x => x.Id == id);
		}

		public void AddCliente(Cliente cliente)
		{
			context.Clientes.Add(cliente);
			context.SaveChanges();
	
		}

		public void UpdateCliente(Cliente cliente)
		{
			context.Clientes.Update(cliente);
			context.SaveChanges();
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
			var query = context.Clientes.Include(c => c.CategoriaNavigation).AsNoTracking().AsQueryable();

			if (categoriaIds != null && categoriaIds.Any())
			{
				query = query.Where(c => categoriaIds.Contains(c.Categoria));
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
