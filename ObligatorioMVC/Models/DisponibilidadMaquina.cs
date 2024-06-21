namespace ObligatorioMVC.Models
{
    public class DisponibilidadMaquina
    {
        public int IdMaquina { get; set; }
        public Maquina Maquina { get; set; }

        public int IdDisponibilidad { get; set; }
        public Disponibilidad Disponibilidad { get; set; }
    }
}
