using System.ComponentModel.DataAnnotations;

namespace ObligatorioMVC.Models
{
    public abstract class Usuario
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        
    }
}
