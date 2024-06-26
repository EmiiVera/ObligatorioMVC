using System.ComponentModel.DataAnnotations;

namespace ObligatorioMVC.Modelos
{
    public class Calificacion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Nota
        {
            get { return Nota; }
            set
            {
                if (value < 0 || value > 5)
                {
                    throw new ArgumentOutOfRangeException("MiNumero", "La nota debe estar entre 0 y 5.");
                }
                Nota = value;
            }
        }
    }
}
