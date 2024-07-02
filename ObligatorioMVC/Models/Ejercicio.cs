using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ObligatorioMVC.Models;

public class Ejercicio
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; }

    [Display(Name = "Máquina")]
    [ForeignKey("TipoMaquina")]
    public int? IdTipoMaquina { get; set; }

    public TipoMaquina? TipoMaquina { get; set; }

    public ICollection<RutinaEjercicio>? RutinaEjercicio { get; set; }


}
