using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioMVC.Models
{
    public class Socio : Usuario
    {
        [Key]
        [Required]
        public int IdLocal { get; set; }
        [Required]
        public Local? local { get; set; }
        public TipoSocio? tipoSocio { get; set; }
        public ICollection<SocioRutina>? socioRutinas { get; set; }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
