using System.ComponentModel.DataAnnotations;

namespace ObligatorioMVC.Models
{
    public abstract class Usuario
    {
        [Key]
        public int IdUsuario {  get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string NombreUsuario { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        public string TelefonoUsuario { get; set; }

        public abstract string ToString();
        
    }
}
