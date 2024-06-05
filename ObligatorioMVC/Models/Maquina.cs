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
        public TipoMaquina? TipoMaquina { get; set; }
        [Required]
        [Display(Name = "Vida útil")]
        public DateTime VidaUtil { get; set; }

        public DateTime VidaUtilRestante()
        {
            DateTime dateTime = DateTime.Now;

            return vidaUtil;
        }
    }
}
