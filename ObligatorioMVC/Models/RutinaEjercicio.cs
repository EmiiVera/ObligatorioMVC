using System.ComponentModel.DataAnnotations;

namespace ObligatorioMVC.Models
{
    public class RutinaEjercicio
    {
        public int IdRutina { get; set; }
        public Rutina Rutina { get; set; }
        public int IdEjercicio { get; set; }
        public Ejercicio? Ejercicio { get; set; }
    }
}
