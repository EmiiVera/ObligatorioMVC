using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioMVC.Models
{
    public class Locales
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
        [Display(Name = "Maquina")]
        [ForeignKey("Maquina")]
        public int? IdMaquina { get; set; }

        public List<Maquina>? Maquinas { get; set; }

        [ForeignKey("ResponsableLocal")]
        public int? IdResponsableLocal { get; set; }
        [Display(Name = "Responsable")]
        public ResponsableLocal? ResponsableLocal { get; set; }

    }
}
