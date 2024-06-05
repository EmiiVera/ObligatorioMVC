namespace ObligatorioMVC.Models
{
    public class Socio : Usuario
    {
        public string tipo {  get; set; }
        public Local local { get; set; }
        public Socio() { }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
