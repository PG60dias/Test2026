using Data.Common;
using Data.Modelo;
using Data.Repository.Common;

namespace Data.Repository.EF
{
	public class CategoriaRepository(TestDbContext context) : ICategoriaRepository
	{
		public Categoria? GetCategoria(int id)
		{
			return context.Categorias.Find(id);
		}

		public IEnumerable<Categoria> GetAllCategorias()
		{
			return [.. context.Categorias];
		}

		public void AddCategoria(Categoria categoria)
		{
			context.Categorias.Add(categoria);
			context.SaveChanges();
		}

		public void UpdateCategoria(Categoria categoria)
		{
			context.Categorias.Update(categoria);
			context.SaveChanges();
		}

		public void DeleteCategoria(int id)
		{
			var categoria = context.Categorias.Find(id);
			if (categoria != null)
			{
				context.Categorias.Remove(categoria);
				context.SaveChanges();
			}
		}
	}
}