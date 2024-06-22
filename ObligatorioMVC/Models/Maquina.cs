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

        [Display(Name = "Disponibilidad")]
        [ForeignKey("Disponibilidad")]
        public int IdDisponible { get; set; }
        public Disponibilidad? Disponibilidad { get; set; }

        //[Required] [Display(Name = "Local")] [ForeignKey("Local")] public int? IdLocal { get; set; } //public Local? Local { get; set; }

        [Display(Name = "Máquina")]
        [ForeignKey("TipoMaquina")]
        public int? IdTipoMaquina { get; set; }

        public TipoMaquina? TipoMaquina { get; set; }

        [Display(Name = "Local")]
        [ForeignKey("Locales")]
        public int? IdLocal {  get; set; }
        public Locales? Locales { get; set; }

        [Required]
        [Display(Name = "Vida Útil(años)")]
        public int VidaUtil { get; set; }

        public int VidaUtilRestante()
        {
            int anio = FechaCompra.Year;
            int vidaRestante = anio + VidaUtil;
            return VidaUtil;


            //"Calcular vida";
        }
    }
}
