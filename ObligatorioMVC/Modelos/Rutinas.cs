using System.ComponentModel.DataAnnotations;

namespace ObligatorioMVC.Modelos
{
    public class Rutinas : Calificacion
    {
        [Key]
        public int Id { get; set; }
        public string descRutina {  get; set; }
        [Required]
        public string tipo {  get; set; }
        [Required]
        public float califProm { get; set; }
    }
}
