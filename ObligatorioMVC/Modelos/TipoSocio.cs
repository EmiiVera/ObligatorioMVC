namespace Obligatorio.Modelos
{
    public class TipoSocio : Socios
    {
        public string Tipo { get; set; }
        public TipoSocio() { }
        public TipoSocio(string tipo)
        {
            Tipo = tipo;
        }
    }
}
