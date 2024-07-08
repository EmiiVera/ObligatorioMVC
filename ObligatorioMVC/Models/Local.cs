using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioMVC.Models
{
    public class Local
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Local")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres.")]
        public string NombreLocal { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Teléfono")]
        public string? TelefonoLocal { get; set; }

        public ICollection<Maquina>? Maquina { get; set; }

        public ICollection<Socio>? Socios { get; set; }

        [ForeignKey("ResponsableLocal")]
        public int? IdResponsableLocal { get; set; }
        //[Display(Name = "Responsable")]
        public Responsable? ResponsableLocal { get; set; }

    }
}
