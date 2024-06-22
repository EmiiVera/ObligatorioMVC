using System.ComponentModel.DataAnnotations;

namespace ObligatorioMVC.Models
{
    public class TipoRutina
    {
        [Key]
        public int IdTipoRutina { get; set; }

        [Required]
        [Display(Name = "Tipo de Rutina")]
        public string NombreTipoRutina { get; set; }

        public ICollection<Socio>? Socios { get; set; }
    }
}
