namespace ObligatorioMVC.Models
{
    public class Maquina
    {
        public int idMaquina { get; set; }
        public DateTime fechaCompra {  get; set; }
        public double precioCompra { get; set; }
        public string disponibilidad { get; set; }
        public TipoMaquina tipoMaquina { get; set; }
        public DateTime vidaUtil { get; set; }

        public DateTime vidaUtilRestante()
        {
            DateTime dateTime = DateTime.Now;

            return vidaUtil;
        }
    }
}
