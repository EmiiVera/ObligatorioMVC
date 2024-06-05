namespace ObligatorioMVC.Models
{
    public class Local
    {
        public int idLocal { get; set; }
        public string nombreLocal { get; set; }
        public string ciudad { get; set; }
        public string direccion { get; set; }
        public string telefonoLocal { get; set; }
        public ResponsableLocal responsableLocal { get; set; }
        public List<Maquina> maquinas { get; set; }
        public Local() { }

    }
}
