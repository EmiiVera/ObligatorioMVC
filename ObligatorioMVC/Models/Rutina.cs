using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioMVC.Models
{
    public class Rutina
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Rutina")]
        public string? DescripcionRutina { get; set; }

        [Display(Name = "Calificación")]
        public int Calificacion { get; set; }

        [Display(Name = "Tipo de Rutina")]
        [ForeignKey("TipoRutina")]
        public int IdTipoRutina { get; set; }
        public TipoRutina? TipoRutina { get; set; }

        public ICollection<SocioRutina>? SocioRutinas { get; set; }

        public ICollection<RutinaEjercicio>? RutinaEjercicios { get; set; }

        [Display(Name = "Ejercicios")]
        [NotMapped]
        public List<int> EjercicioSeleccionados { get; set; }
    }
}
