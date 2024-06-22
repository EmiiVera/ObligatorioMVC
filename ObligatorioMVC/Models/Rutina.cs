using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioMVC.Models
{
    public class Rutina
    {
        [Key]
        public int IdRutina { get; set; }

        [Required]
        [Display(Name = "Rutina")]
        public string? DescripcionRutina { get; set; }

        [Display(Name = "Calificación")]
        public int Calificacion { get; set; }

        [Display(Name = "Tipo de Rutina")]
        [ForeignKey("TipoRutina")]
        public int tipoRutina { get; set; }
        public TipoRutina? TipoRutina { get; set; }

        public ICollection<SocioRutina>? socioRutinas { get; set; }

        public ICollection<RutinaEjercicio>? rutinaEjercicios { get; set; }
    }
}
