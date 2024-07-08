using System.ComponentModel.DataAnnotations;

namespace ObligatorioMVC.Models
{
    public class TipoRutina
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Tipo de Rutina")]
        public string Nombre { get; set; }

        public ICollection<Rutina>? Rutinas { get; set; }
    }
}
