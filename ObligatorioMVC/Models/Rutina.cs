using System.ComponentModel.DataAnnotations;

namespace ObligatorioMVC.Models
{
    public class Rutina
    {
        [Key]
        public int IdRutina { get; set; }
        [Required]
        [Display(Name = "Tipo de Rutina")]
        public string TipoRutina { get; set; }
        public string? Descripcion { get; set; }
        public double? Promedio { get; set; }

    }
}
