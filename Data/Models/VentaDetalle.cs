using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
	public class VentaDetalle
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int VentaId { get; set; }

		[ForeignKey("VentaId")]
		public virtual Venta? Venta { get; set; }

		[Required]
		public int ArticuloId { get; set; }

		[ForeignKey("ArticuloId")]
		public virtual Articulo? Articulo { get; set; }

		[Required]
		public int Cantidad { get; set; }

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal PrecioAplicado { get; set; }
	}
}