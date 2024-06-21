using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioMVC.Models
{
    public class Disponibilidad
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Nombre { get; set; }

        //[ForeignKey("Maquina")]
        //public int? IdMaquina { get; set; }
        //public List<Maquina>? Maquinas { get; set; }  

        
    }
}
