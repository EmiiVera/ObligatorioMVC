using System.ComponentModel.DataAnnotations;

namespace Obligatorio.Modelos
{
    public abstract class Persona
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; } 
        public string Mail { get; set; }
    }
}