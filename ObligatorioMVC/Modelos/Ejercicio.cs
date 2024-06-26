using Obligatorio.Modelos;
using System.ComponentModel.DataAnnotations;

namespace ObligatorioMVC.Modelos
{
    public class Ejercicio
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        [Required]
        public Maquinas Maquina {  get; set; }
    }
}
