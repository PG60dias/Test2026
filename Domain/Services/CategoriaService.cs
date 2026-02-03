using Data.Modelo;
using Data.Repository.Common;

namespace Domain.Services
{
	public class CategoriaService(ICategoriaRepository repository)
	{
		private readonly ICategoriaRepository _repository = repository;

		public IEnumerable<Categoria> GetCategorias()
		{
			return _repository.GetAllCategorias();
		}
	}
}