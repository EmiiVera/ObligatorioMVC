using System.ComponentModel.DataAnnotations;

namespace ObligatorioMVC.Models
{
    public class TipoMaquina
    {
        [Key]
        public int IdTipoMaquina { get; set; }

        [Required]
        [Display(Name = "Tipo de Máquina")]
        public string NombreTipoMaquina { get; set; }

        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }
    }
}
