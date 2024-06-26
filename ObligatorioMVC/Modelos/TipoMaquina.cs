using System.ComponentModel.DataAnnotations;

namespace Obligatorio.Modelos
{
    public class TipoMaquina : Maquinas
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set;}

        public TipoMaquina() { }
        public TipoMaquina(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
