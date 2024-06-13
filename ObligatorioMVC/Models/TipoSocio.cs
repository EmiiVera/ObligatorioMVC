using System.ComponentModel.DataAnnotations;

namespace ObligatorioMVC.Models
{
    public class TipoSocio
    {
        [Key]
        public int IdTipoSocio { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
