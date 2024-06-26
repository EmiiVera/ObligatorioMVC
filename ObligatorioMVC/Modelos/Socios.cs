namespace Obligatorio.Modelos
{
    public class Socios : Persona
    {
        public TipoSocio TipoSocio { get; set; }
        public Locales Local { get; set; }

        public Socios() { }
        public Socios(int id, string nombre, string telefono, string mail, TipoSocio tipoSocio, Locales locales)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
            Mail = mail;
            TipoSocio = tipoSocio;
            Local = locales;
        }
    }
}
