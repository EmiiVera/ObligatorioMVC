using System.ComponentModel.DataAnnotations;

namespace Obligatorio.Modelos
{
    public class Locales
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Responsable Responsable { get; set; }
        public List<Maquinas> Maquinas { get; set; }

        public Locales() { }
        public Locales(int id, string nombre, string ciudad, string direccion, string telefono, Responsable responsable, List<Maquinas> maquinas)
        {
            Id = id;
            Nombre = nombre;
            Ciudad = ciudad;
            Direccion = direccion;
            Telefono = telefono;
            Responsable = responsable;
            Maquinas = maquinas;
        }
    }
}
