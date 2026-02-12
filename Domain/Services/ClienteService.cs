using Data.DTOs;
using Data.Modelo;
using Data.Repository.Common;

namespace Domain.Services
{
	public class ClienteService
	{
		// Repositorio síncrono original (usado por Desktop)
		public IClienteRepository Repository { get; }

		// Nuevo repositorio asíncrono (usado por WebBlazor)
		private readonly IClienteRepositoryAsync _repositoryAsync;

		// Constructor modificado: 
		// Desktop inyectará solo el síncrono. 
		// WebBlazor inyectará ambos o el que necesites.
		public ClienteService(IClienteRepository repository, IClienteRepositoryAsync repositoryAsync = null)
		{
			Repository = repository;
			_repositoryAsync = repositoryAsync;
		}

		/// <summary>
		/// Método exclusivo para Blazor Web. 
		/// Utiliza el nuevo repositorio asíncrono para evitar bloqueos de UI.
		/// </summary>
		public async Task<IEnumerable<ClienteDTO>> GetClientesFiltradosWebAsync(List<int> categoriaIds = null, string busqueda = null)
		{
			if (_repositoryAsync == null)
			{
				throw new InvalidOperationException("El repositorio asíncrono no está configurado.");
			}

			return await _repositoryAsync.GetClientesFiltradosAsync(categoriaIds, busqueda?.Trim());
		}

		/// <summary>
		/// Método original usado por el programa Desktop.
		/// Se mantiene intacto para no romper la compatibilidad.
		/// </summary>
		public IEnumerable<ClienteDTO> GetClientesFiltrados(List<int> categoriaIds = null, string busqueda = null)
		{
			return Repository.GetClientesFiltrados(categoriaIds, busqueda?.Trim());
		}

		public static void UpdateNombre(Cliente cliente)
		{
			if (!string.IsNullOrEmpty(cliente.Nombre))
			{
				cliente.Nombre = cliente.Nombre.ToUpper();
			}
		}

		public bool HanCambiadoLosDatos(Cliente original, string nombre, string direccion, string email, string telefono, int categoriaId)
		{
			return original.Nombre != nombre ||
				   original.Direccion != direccion ||
				   original.Email != email ||
				   original.Telefono != telefono ||
				   original.Categoria != categoriaId;
		}
	}
}