using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
	public class Venta
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int ClienteId { get; set; }

		[Required]
		public DateTime Fecha { get; set; }

		public virtual ICollection<VentaDetalle> Detalles { get; set; } = new List<VentaDetalle>();
	}
}