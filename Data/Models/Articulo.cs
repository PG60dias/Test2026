using System.ComponentModel.DataAnnotations.Schema;
using Data.Models;

public class Articulo
{
	public int Id { get; set; }
	public string Nombre { get; set; } = string.Empty;

	public int IdCategoria { get; set; }

	[ForeignKey("IdCategoria")]
	public CategoriaProducto? Categoria { get; set; }

	public decimal PVP { get; set; }
	public decimal PrecioUltimaVenta { get; set; }
}