namespace ObligatorioMVC.Models
{
    public class SocioRutina
    {
        public int IdSocio { get; set; }
        public Socio? Socio { get; set; }

        public int IdRutina { get; set; }
        public Rutina? Rutina { get; set; }
    }
}
