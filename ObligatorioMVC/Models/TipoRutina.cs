using System.ComponentModel.DataAnnotations;

namespace ObligatorioMVC.Models
{
    public class TipoRutina
    {
        [Key]
        public int IdTipoRutina { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
