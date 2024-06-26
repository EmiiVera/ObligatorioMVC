namespace Obligatorio.Modelos
{
    public class Responsable : Persona
    {
        public double Sueldo { get; set; }

        public Responsable() { }
        public Responsable(int id, string nombre, string telefono, string mail, double sueldo)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
            Mail = mail;
            Sueldo = sueldo;
        } 
    }
}
