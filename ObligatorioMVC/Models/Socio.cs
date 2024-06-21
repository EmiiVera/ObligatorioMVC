using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioMVC.Models
{
    public class Socio : Usuario
    {
        [Required]
        [ForeignKey("Local")]
        public int IdLocal { get; set; }

        [Required]
        public Locales? Locales { get; set; }

        [Display(Name = "Tipo de Socio")]
        [ForeignKey("TipoSocio")]
        public int IdTipoSocio { get; set; }
        public TipoSocio? tipoSocio { get; set; }

        public ICollection<SocioRutina>? socioRutinas { get; set; }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
