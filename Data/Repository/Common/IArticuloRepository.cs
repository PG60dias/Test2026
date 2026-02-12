using Data.Models;

namespace Data.Repository.Common
{
	public interface IArticuloRepository
	{
		Task<IEnumerable<Articulo>> GetArticulosAsync();
		Task<IEnumerable<CategoriaProducto>> GetCategoriasProductosAsync();
		Task GenerarVentasMasivasAsync(int cantidad);
		Task<IEnumerable<Venta>> GetVentasAsync();
		Task LimpiarVentasAsync();
	}
}