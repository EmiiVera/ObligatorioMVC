using System.ComponentModel.DataAnnotations;

namespace Obligatorio.Modelos
{
    public class Maquinas
    {
        [Key]
        public int Id { get; set; }
        public Locales Local { get; set; }
        public DateTime FechaCompra { get; set; }
        public double Precio { get; set; }
        public int VidaUtil { get; set; }
        public TipoMaquina TipoMaquina { get; set; }
        public bool Disponible { get; set; }

        public Maquinas() { }
        public Maquinas(int id, Locales local, DateTime fechaCompra, double precio, int vidaUtil, TipoMaquina tipoMaquina, bool disponible)
        {
            Id = id;
            Local = local;
            FechaCompra = fechaCompra;
            Precio = precio;
            VidaUtil = vidaUtil;
            TipoMaquina = tipoMaquina;
            Disponible = disponible;
        }
    }
}
