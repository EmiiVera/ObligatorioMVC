namespace ObligatorioMVC.Models
{
    public class SocioRutina
    {
        public int idSocio { get; set; }
        public Socio? Socio { get; set; }
        public int idRutina { get; set; }
        public Rutina? Rutina { get; set; } 

    }
}
