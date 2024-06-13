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
        [Required]
        public string Ciudad { get; set; }
        [Required]
        [Display(Name = "Dirección")]

        public string Direccion { get; set; }
        [Required]
        [Display(Name = "Teléfono")]
        public string? TelefonoLocal { get; set; }
        [Required]
        [Display(Name = "Responsable")]

        public int idResponsableLocal { get; set; }
        public ResponsableLocal? ResponsableLocal { get; set; }
        public List<Maquina>? Maquinas { get; set; }

    }
}
