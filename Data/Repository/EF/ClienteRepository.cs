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

		public IEnumerable<Cliente> GetClientesFiltrados(string filtro)
		{
			bool esNumero = int.TryParse(filtro, out int id);

			return context.Clientes
				.Include(c => c.CategoriaNavigation)
				.Where(c => (esNumero && c.Id == id) ||
							(c.Nombre != null && c.Nombre.Contains(filtro)) ||
							(c.Direccion != null && c.Direccion.Contains(filtro)) ||
							(c.Email != null && c.Email.Contains(filtro)) ||
							(c.Telefono != null && c.Telefono.Contains(filtro)))
				.ToList();
		}
	}
}
