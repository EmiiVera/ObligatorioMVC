using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioMVC.Models
{
    public class Socio : Usuario
    {
        [Required]
        public int IdLocal { get; set; }
        [Required]
        public string Tipo {  get; set; }
        [Required]
        public Local local { get; set; }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
