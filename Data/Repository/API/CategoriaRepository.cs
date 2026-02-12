
using Data.Common;
using Data.Modelo;
using Data.Repository.Common;

namespace Data.Repository.API
{
	public class CategoriaRepository : ICategoriaRepository
	{
		private readonly TestDbContext _context;

		public CategoriaRepository(TestDbContext context)
		{
			_context = context;
		}

        public void AddCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> GetAllCategorias()
		{
			return _context.Categorias.ToList();
		}

        public Categoria? GetCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}




