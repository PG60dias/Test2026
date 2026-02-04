using Data.Modelo;
using Data.Repository.Common;
using System.Collections.ObjectModel;

namespace Data.Repository.Local
{
    public class ClienteRepository : IClienteRepository
    {
        private ObservableCollection<Cliente> _clientes =
        [
            new Cliente { Id = 1, Nombre = "Cliente Uno", Email = "email 1", Direccion = "Direccion 1" },
            new Cliente { Id = 2, Nombre = "Cliente Dos", Email = "email 2", Direccion = "Direccion 2" },
            new Cliente { Id = 3, Nombre = "Cliente Tres", Email = "email 3", Direccion = "Direccion 3" }
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
            }
        }

        public void DeleteCliente(int id)
        {
            var c = GetCliente(id);
            _clientes.Remove(c);
        }

        public IEnumerable<Cliente> GetClientesFiltrados(List<int> categoriaIds = null, string busqueda = null)
        {
            throw new NotImplementedException();
        }
    }
}
