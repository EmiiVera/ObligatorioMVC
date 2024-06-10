using System.ComponentModel.DataAnnotations;
namespace ObligatorioMVC.Models;

public class Ejercicio
{
    [Key]
    public int IdEjercicio { get; set; }
    [Display(Name = "Máquina")]
    [Required]
    public int IdTipoMaquina { get; set; }
    public Maquina? Maquina { get; set; }

}
