using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ObligatorioMVC.Models;

public class Ejercicio
{
    [Key]
    public int IdEjercicio { get; set; }

    [Required]
    [Display(Name = "Máquina")]
    [ForeignKey("TipoMaquina")]
    public int IdTipoMaquina { get; set; }

    public TipoMaquina? tipoMaquina { get; set; }

    public ICollection<RutinaEjercicio> rutinaEjercicios { get; set; }


}
