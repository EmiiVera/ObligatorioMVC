using System.ComponentModel.DataAnnotations;

namespace ObligatorioMVC.Models
{
    public class TipoMaquina
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tipo de Máquina")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }
    }
}
