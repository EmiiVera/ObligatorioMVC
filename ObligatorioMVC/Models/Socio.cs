using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioMVC.Models
{
    public class Socio : Usuario
    {
        [Required]
        [ForeignKey("Local")]
        public int IdLocal { get; set; }

        public Local? Local { get; set; }

        [Display(Name = "Tipo de Socio")]
        [ForeignKey("TipoSocio")]
        public int IdTipoSocio { get; set; }
        public TipoSocio? TipoSocio { get; set; }

        public ICollection<SocioRutina>? SocioRutinas { get; set; }
    }
}
