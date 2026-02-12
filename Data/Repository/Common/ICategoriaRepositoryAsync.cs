using Data.Modelo;

namespace Data.Repository.Common
{
	public interface ICategoriaRepositoryAsync
	{
		Task<IEnumerable<Categoria>> GetAllCategoriasAsync();
		Task<Categoria?> GetCategoriaAsync(int id);
		Task AddCategoriaAsync(Categoria categoria);
		Task UpdateCategoriaAsync(Categoria categoria);
		Task DeleteCategoriaAsync(int id);
	}
}