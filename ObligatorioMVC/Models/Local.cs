using System.ComponentModel.DataAnnotations;

namespace ObligatorioMVC.Models
{
    public class Local
    {
        [Key]
        public int IdLocal { get; set; }
        [Required]
        [Display(Name = "Local")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres.")]
        public string NombreLocal { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        [Required]
        [Display(Name = "Teléfono")]
        public string TelefonoLocal { get; set; }
        public ResponsableLocal? ResponsableLocal { get; set; }
        public List<Maquina>? Maquinas { get; set; }

    }
}
