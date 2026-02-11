using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
	[Table("Logs")] 
	public class Log
	{
		[Key]
		public int Id { get; set; }
		public int UsuarioId { get; set; }
		public int EntidadId { get; set; }
		public string Entidad { get; set; }
		public string Accion { get; set; }
		public string? ValorViejo { get; set; }
		public string? ValorNuevo { get; set; }
		public DateTime Fecha { get; set; }
	}
}