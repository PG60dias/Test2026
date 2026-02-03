using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using PropertyChanged;

namespace Data.Modelo;

[AddINotifyPropertyChangedInterface]
public partial class Cliente 
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(50)]
    [Unicode(false)]
    public string? Direccion { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    public int? Categoria { get; set; }

	[NotMapped]
	public string CategoriaNombre => CategoriaNavigation?.Nombre;

	[ForeignKey("Categoria")]
	public virtual Categoria? CategoriaNavigation { get; set; }
}
