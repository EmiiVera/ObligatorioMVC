namespace ObligatorioMVC.Models
{
    public abstract class Usuario
    {
        public int idUsuario {  get; set; }
        public string nombreUsuario { get; set; }
        public string telefonoUsuario { get; set; }

        public abstract string ToString();
        
    }
}
