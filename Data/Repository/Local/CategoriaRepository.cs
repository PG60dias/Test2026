
using Data.Modelo;
using Data.Repository.Common;

namespace Data.Repository.Local
{
	public class CategoriaRepository : ICategoriaRepository
	{

		private List<Categoria> _categorias =
		[
			new Categoria { Id = 1, Nombre = "Standard" },
			new Categoria { Id = 2, Nombre = "Premium" },
			new Categoria { Id = 3, Nombre = "Prueba" }
		];

		public Categoria? GetCategoria(int id)
		{
			return _categorias.FirstOrDefault(c => c.Id == id);
		}

		public IEnumerable<Categoria> GetAllCategorias()
		{
			return _categorias;
		}

		public void AddCategoria(Categoria categoria)
		{
			if (_categorias.Count != 0)
				categoria.Id = _categorias.Max(c => c.Id) + 1;
			else
				categoria.Id = 1;

			_categorias.Add(categoria);
		}

		public void UpdateCategoria(Categoria categoria)
		{
			var categoriaExistente = GetCategoria(categoria.Id);
			if (categoriaExistente != null)
			{
				categoriaExistente.Nombre = categoria.Nombre;
			}
		}

		public void DeleteCategoria(int id)
		{
			var categoria = GetCategoria(id);
			if (categoria != null)
			{
				_categorias.Remove(categoria);
			}
		}
	}
}