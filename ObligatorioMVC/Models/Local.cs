namespace ObligatorioMVC.Models
{
    public class Local
    {
        [Key]
        public int IdLocal { get; set; }
        [Required]
        [Display(Name = "Local")]
        public string NombreLocal { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        [Required]
        [Display(Name = "Teléfono")]
        public string TelefonoLocal { get; set; }
        public ResponsableLocal? ResponsableLocal { get; set; }
        public List<Maquina>? Maquinas { get; set; }

    }
}
