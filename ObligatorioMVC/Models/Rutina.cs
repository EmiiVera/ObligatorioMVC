using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioMVC.Models
{
    public class Rutina
    {
        [Key]
        public int IdRutina { get; set; }

        [Required]
        [Display(Name = "Tipo de Rutina")]
        public string? Descripcion { get; set; }

        public double? Promedio { get; set; }

        [Display(Name = "Tipo de Rutina")]
        [ForeignKey("TipoRutina")]
        public int tipoRutina { get; set; }
        public TipoRutina? TipoRutina { get; set; }

        public ICollection<SocioRutina>? socioRutinas { get; set; }

        public ICollection<RutinaEjercicio> rutinaEjercicios { get; set; }
    }
}
