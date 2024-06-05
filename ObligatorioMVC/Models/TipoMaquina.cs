namespace ObligatorioMVC.Models
{
    public class TipoMaquina
    {
        [Key]
        public int idTipoMaquina { get; set; }
        [Required]
        [Display(Name = "Tipo de Máquina")]
        public string nombreTipoMaquina { get; set; }
    }
}
