using System.ComponentModel.DataAnnotations;

namespace ObligatorioMVC.Models
{
    public abstract class Usuario
    {
        [Key]
        public int Id {  get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        
    }
}
