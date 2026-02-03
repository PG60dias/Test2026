using Data.Modelo;

namespace Data.Repository.Common
{
	public interface ICategoriaRepository
	{
		Categoria? GetCategoria(int id);
		IEnumerable<Categoria> GetAllCategorias();
		void AddCategoria(Categoria categoria);
		void UpdateCategoria(Categoria categoria);
		void DeleteCategoria(int id);
	}
}