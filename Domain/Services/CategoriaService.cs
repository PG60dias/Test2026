using Data.Modelo;
using Data.Repository.Common;

namespace Domain.Services
{
	public class CategoriaService
	{
		private readonly ICategoriaRepository _repository;

		public CategoriaService(ICategoriaRepository repository)
		{
			_repository = repository;
		}

		public IEnumerable<Categoria> GetAllCategorias()
		{
			return _repository.GetAllCategorias();
		}
	}
}