namespace ObligatorioMVC.Models
{
    public class Rutina
    {
        public int idRutina { get; set; }
        public string tipoRutina { get; set; }
        public string descripcion { get; set; }
        public double promedio { get; set; }
        public void Promedio ()
        {
            promedio = 0; //calcular promedio
        }
    }
}
