using System.ComponentModel.DataAnnotations;

namespace ObligatorioMVC.Models
{
    public class TipoSocio
    {
        [Key]
        public int IdTipoSocio { get; set; }
        [Required]
        [Display(Name = "Tipo de Socio")]
        public string NombreTipoSocio { get; set; }
    }
}
