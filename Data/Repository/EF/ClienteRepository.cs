using Data.Common;
using Data.Modelo;
using Data.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.EF
{
    public class ClienteRepository(TestDbContext context) : IClienteRepository
    {

        public Cliente? GetCliente(int id)
        {
            return context.Clientes.Find(id);
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            return [.. context.Clientes.AsNoTracking()//Importante para referescar el grid
                                .Include(c => c.CategoriaNavigation).ToList()];
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

		public IEnumerable<Cliente> GetClientesFiltrados(List<int> categoriaIds = null, string busqueda = null)
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

			return query.ToList();
		}

	}
}
