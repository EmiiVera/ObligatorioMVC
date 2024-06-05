using System.ComponentModel.DataAnnotations;
namespace ObligatorioMVC.Models;

public class Ejercicio
{
    [key]
    public int IdEjercicio { get; set; }
    [Display(Name = "Máquina")]
    public Maquina? Maquina { get; set; }

}
