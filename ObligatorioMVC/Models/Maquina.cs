using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioMVC.Models
{
    public class Maquina
    {
        [Key]
        public int IdMaquina { get; set; }

        [Required]
        [Display(Name = "Fecha de la compra")]
        public DateTime FechaCompra {  get; set; }

        [Required]
        [Display(Name = "Precio")]
        public double PrecioCompra { get; set; }

        [Required]
        public string Disponibilidad { get; set; }

        [Required]
        [Display(Name = "Local")]
        [ForeignKey("Local")]
        public int IdLocal { get; set; }

        public Local? local { get; set; }

        [Required]
        [Display(Name = "Máquina")]
        [ForeignKey("TipoMaquina")]
        public int IdTipoMaquina { get; set; }

        [Required]
        public TipoMaquina? TipoMaquina { get; set; }

        [Required]
        [Display(Name = "Vida útil")]
        public DateTime VidaUtil { get; set; }

        public void VidaUtilRestante()
        {
            DateTime dateTime = DateTime.Now;

            //"Calcular vida";
        }
    }
}
