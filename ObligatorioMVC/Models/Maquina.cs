using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioMVC.Models
{
    public class Maquina
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Fecha de la compra")]
        public DateTime FechaCompra {  get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Precio")]
        public double PrecioCompra { get; set; }
        public bool Disponibilidad { get; set; }

        //[Required(ErrorMessage = "Campo obligatorio")] [Display(Name = "Local")] [ForeignKey("Local")] public int? IdLocal { get; set; } //public Local? Local { get; set; }

        [Display(Name = "Máquina")]
        [ForeignKey("TipoMaquina")]
        public int? IdTipoMaquina { get; set; }

        public TipoMaquina? TipoMaquina { get; set; }

        [Display(Name = "Local")]
        [ForeignKey("Local")]
        public int IdLocal {  get; set; }
        public Local? Local { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
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
