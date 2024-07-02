using System.ComponentModel.DataAnnotations;

namespace ObligatorioMVC.Models
{
    public class TipoSocio
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tipo de Socio")]
        public string Nombre { get; set; }
        public ICollection<Socio>? Socios { get; set; }
    }
}
