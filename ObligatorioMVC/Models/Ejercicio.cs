using System.ComponentModel.DataAnnotations;
namespace ObligatorioMVC.Models;

public class Ejercicio
{
    [Key]
    public int IdEjercicio { get; set; }
    [Display(Name = "Máquina")]
    [Required]
    public int IdTipoMaquina { get; set; }
    public TipoMaquina? tipoMaquina { get; set; }
    public ICollection<RutinaEjercicio> rutinaEjercicios { get; set; }


}
